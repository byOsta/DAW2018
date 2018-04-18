using Contoso.NLayer.DataLayer.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsMVC.DataLayer.Models
{
	public class UnitOfWork<TContext> : IUnitOfWork, IDisposable
	 where TContext : DbContext
	{
		#region Constructor

		public UnitOfWork(IDbContextFactory<TContext> factory)
		{
			ContextFactory = factory;
			_repositories = new ConcurrentDictionary<Type, object>();
		}

		#endregion Constructor

		#region Properties

		private ConcurrentDictionary<Type, object> _repositories;

		private IDbContextFactory<DbContext> ContextFactory { get; set; }

		private DbContext _context;
		public DbContext Context
		{
			get
			{
				if (_context == null)
				{
					_context = this.ContextFactory.Create();
				}
				return _context;
			}
		}

		private bool IsDisposed { get; set; }

		#endregion Properties

		#region Methods

		public bool CheckDBExists()
		{
			return this.Context.Database.Exists();
		}

		public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
		{
			return (Repository<TEntity>)_repositories.GetOrAdd(typeof(TEntity), new Repository<TEntity>(this.Context));
		}

		public ValidationResult Validate()
		{
			ValidationResult result = new ValidationResult()
			{
				IsValid = true
			};

			var errors = this.Context.GetValidationErrors();
			List<String> mensajes = new List<String>();
			foreach (var error in errors)
			{
				foreach (var item in error.ValidationErrors)
				{
					mensajes.Add(string.Format("{0} - {1}", item.PropertyName, item.ErrorMessage));
				}
			}

			if (errors.Any() && mensajes.Count > 0)
			{
				result.IsValid = false;
				result.ErrorMessages = mensajes;
			}

			return result;
		}

		public virtual bool Save()
		{
			try
			{
				ValidationResult validation = this.Validate();
				if (validation.IsValid)
				{
					return 0 < this.Context.SaveChanges();
				}
				else
				{
					throw new Exception(string.Join(",", validation.ErrorMessages));
				}
			}
			catch (DbEntityValidationException dbEx)
			{
				foreach (var validationErrors in dbEx.EntityValidationErrors)
				{
					foreach (var validationError in validationErrors.ValidationErrors)
					{
						Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
					}
				}
				throw;
			}
		}

		public virtual async Task<bool> SaveAsync()
		{
			try
			{
				ValidationResult validation = this.Validate();
				if (validation.IsValid)
				{
					return 0 < await this.Context.SaveChangesAsync();
				}
				else
				{
					throw new Exception(string.Join(",", validation.ErrorMessages));
				}
			}
			catch (DbEntityValidationException dbEx)
			{
				foreach (var validationErrors in dbEx.EntityValidationErrors)
				{
					foreach (var validationError in validationErrors.ValidationErrors)
					{
						Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
					}
				}
				throw;
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this.IsDisposed)
			{
				if (disposing && _context != null)
				{
					_context.Dispose();
				}
			}
			this.IsDisposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion Methods

	}

	public class ValidationResult
	{
		public bool IsValid { get; set; }
		public IEnumerable<string> ErrorMessages { get; set; }

		public string NotificationType { get; set; }
	}
}