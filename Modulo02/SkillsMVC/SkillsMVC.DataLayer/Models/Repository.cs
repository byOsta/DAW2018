using LinqKit;
using SkillsMVC.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contoso.NLayer.DataLayer.Models
{
	public class Repository<TEntity> : IRepository<TEntity>
		where TEntity : class
	{
		#region Constructor Region

		public Repository(DbContext context)
		{
			this.Context = context;
		}

		#region Properties

		private DbContext Context { get; set; }

		#endregion Properties

		#endregion

		#region Create Region

		public virtual TEntity Create()
		{
			return this.Context.Set<TEntity>().Create();
		}

		public virtual void Create(TEntity entity)
		{
			this.Context.Entry(entity).State = EntityState.Added;
			this.Context.Set<TEntity>().Add(entity);
		}

		#endregion

		#region Update Region

		public virtual TEntity Update(TEntity entity)
		{
			DbEntityEntry<TEntity> entry = this.Context.Entry(entity);
			if (entry.State == EntityState.Detached)
			{
				this.Context.Set<TEntity>().Attach(entity);
			}
			this.Context.Entry(entity).State = EntityState.Modified;

			return entity;
		}

		#endregion

		#region Delete Region

		public virtual void Delete(long id)
		{
			var item = this.Context.Set<TEntity>().Find(id);
			this.Context.Set<TEntity>().Remove(item);
		}

		public virtual void Delete(TEntity entity)
		{
			if (this.Context.Entry(entity).State == EntityState.Detached)
			{
				this.Context.Set<TEntity>().Attach(entity);
			}
			this.Context.Set<TEntity>().Remove(entity);
		}

		public virtual void Delete(Expression<Func<TEntity, bool>> where)
		{
			var objects = this.Context.Set<TEntity>().Where(where).AsEnumerable();
			foreach (var item in objects)
			{
				this.Context.Set<TEntity>().Remove(item);
			}
		}

		#endregion

		#region Find Region

		public virtual TEntity FindById(long id)
		{
			return this.Context.Set<TEntity>().Find(id);
		}

		public virtual TEntity FindOne(bool setAsNoTracking = false)
		{
			if (setAsNoTracking)
			{
				return this.Context.Set<TEntity>().AsNoTracking().FirstOrDefault();
			}
			else
			{
				return this.Context.Set<TEntity>().FirstOrDefault();
			}
		}

		public virtual TEntity FindOne(Expression<Func<TEntity, bool>> where,
										params Expression<Func<TEntity, object>>[] includes)
		{
			return this.FindOne(where, false, includes);
		}

		public virtual TEntity FindOne(Expression<Func<TEntity, bool>> where,
										bool setAsNoTracking = false,
										params Expression<Func<TEntity, object>>[] includes)
		{
			if (where == null)
			{
				return FindAll(null, setAsNoTracking, includes).FirstOrDefault();
			}
			else
			{
				return FindAll(where, setAsNoTracking, includes).FirstOrDefault();
			}
		}

		public IQueryable<T> Set<T>(bool setAsNoTracking = false) where T : class
		{
			if (setAsNoTracking)
			{
				return this.Context.Set<T>().AsNoTracking();
			}
			else
			{
				return this.Context.Set<T>();
			}
		}

		public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null,
													params Expression<Func<TEntity, object>>[] includes)
		{
			return FindAll(where, false, includes);
		}

		public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null,
													bool setAsNoTracking = false,
													params Expression<Func<TEntity, object>>[] includes)
		{
			IQueryable<TEntity> query = null;
			if (setAsNoTracking)
			{
				query = where == null ? this.Context.Set<TEntity>().AsNoTracking() : this.Context.Set<TEntity>().AsNoTracking().Where(where);
			}
			else
			{
				query = where == null ? this.Context.Set<TEntity>() : this.Context.Set<TEntity>().Where(where);
			}
			foreach (var include in includes)
				query = query.Include(include);

			return query.ToList();
		}

		public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null, bool setAsNoTracking = false)
		{
			IQueryable<TEntity> query = null;
			if (setAsNoTracking)
			{
				query = where == null ? this.Context.Set<TEntity>().AsNoTracking() : this.Context.Set<TEntity>().AsExpandable<TEntity>().AsNoTracking().Where(where);
			}
			else
			{
				query = where == null ? this.Context.Set<TEntity>() : this.Context.Set<TEntity>().AsExpandable<TEntity>().Where(where);
			}

			return query.ToList();
		}


		public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where, string[] includes, bool setAsNoTracking = false)
		{
			IQueryable<TEntity> query = null;
			if (setAsNoTracking)
			{
				query = where == null ? this.Context.Set<TEntity>().AsNoTracking() : this.Context.Set<TEntity>().AsNoTracking().Where(where);
			}
			else
			{
				query = where == null ? this.Context.Set<TEntity>() : this.Context.Set<TEntity>().Where(where);
			}

			foreach (var include in includes)
				query = query.Include(include);

			return query;
		}
		public virtual async Task<TEntity> FindByIdAsync(long id)
		{
			return await this.Context.Set<TEntity>().FindAsync(id);
		}

		public async virtual Task<TEntity> FindOneAsync(bool setAsNoTracking = false)
		{
			if (setAsNoTracking)
			{
				return await this.Context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync();
			}
			else
			{
				return await this.Context.Set<TEntity>().FirstOrDefaultAsync();
			}
		}

		public virtual async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> where,
										params Expression<Func<TEntity, object>>[] includes)
		{
			return await this.FindOneAsync(where, false, includes);
		}

		public virtual async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> where,
										bool setAsNoTracking = false,
										params Expression<Func<TEntity, object>>[] includes)
		{
			if (where == null)
			{
				var items = await this.FindAllAsync(null, setAsNoTracking, includes);
				return items.FirstOrDefault();
			}
			else
			{
				var items = await this.FindAllAsync(where, setAsNoTracking, includes);
				return items.FirstOrDefault();
			}
		}

		public virtual async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> where = null,
													params Expression<Func<TEntity, object>>[] includes)
		{
			return await FindAllAsync(where, false, includes);
		}

		public virtual async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> where = null,
													bool setAsNoTracking = false,
													params Expression<Func<TEntity, object>>[] includes)
		{
			IQueryable<TEntity> query = null;
			if (setAsNoTracking)
			{
				query = where == null ? this.Context.Set<TEntity>().AsNoTracking() : this.Context.Set<TEntity>().AsNoTracking().Where(where);
			}
			else
			{
				query = where == null ? this.Context.Set<TEntity>() : this.Context.Set<TEntity>().Where(where);
			}
			foreach (var include in includes)
				query = query.Include(include);

			return await query.ToListAsync();
		}

		public virtual async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> where = null, bool setAsNoTracking = false)
		{
			IQueryable<TEntity> query = null;
			if (setAsNoTracking)
			{
				query = where == null ? this.Context.Set<TEntity>().AsNoTracking() : this.Context.Set<TEntity>().AsExpandable<TEntity>().AsNoTracking().Where(where);
			}
			else
			{
				query = where == null ? this.Context.Set<TEntity>() : this.Context.Set<TEntity>().AsExpandable<TEntity>().Where(where);
			}

			return await query.ToListAsync();
		}


		public virtual async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> where, string[] includes, bool setAsNoTracking = false)
		{
			IQueryable<TEntity> query = null;
			if (setAsNoTracking)
			{
				query = where == null ? this.Context.Set<TEntity>().AsNoTracking() : this.Context.Set<TEntity>().AsNoTracking().Where(where);
			}
			else
			{
				query = where == null ? this.Context.Set<TEntity>() : this.Context.Set<TEntity>().Where(where);
			}

			foreach (var include in includes)
				query = query.Include(include);

			return await query.ToListAsync();
		}

		#endregion
	}
}