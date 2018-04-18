using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SkillsMVC.DataLayer.Models
{
	public interface IRepository<TEntity>
	{
		/// <summary>
		/// Creates a new empty entity.
		/// </summary>
		TEntity Create();

		/// <summary>
		/// Creates the existing entity.
		/// </summary>
		void Create(TEntity entity);

		/// <summary>
		/// Updates the existing entity.
		/// </summary>
		TEntity Update(TEntity entity);

		/// <summary>
		/// Delete an entity using its primary key.
		/// </summary>
		void Delete(long id);

		/// <summary>
		/// Delete the given entity.
		/// </summary>
		void Delete(TEntity entity);

		/// <summary>
		/// Deletes the existing entity.
		/// </summary>
		void Delete(Expression<Func<TEntity, bool>> where);

		/// <summary>
		/// Finds one entity based on provided criteria.
		/// </summary>
		TEntity FindOne(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);

		/// <summary>
		/// Finds one entity based on provided criteria.
		/// </summary>
		TEntity FindOne(Expression<Func<TEntity, bool>> where,
										bool setAsNoTracking = false,
										params Expression<Func<TEntity, object>>[] includes);

		/// <summary>
		/// Finds one entity based on provided criteria.
		/// </summary>
		TEntity FindOne(bool setAsNoTracking = false);

		/// <summary>
		/// Finds one entity based on its Identifier.
		/// </summary>
		TEntity FindById(long id);

		/// <summary>
		/// Finds entities based on provided criteria.
		/// </summary>
		IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);

		/// <summary>
		/// Finds entities based on provided criteria.
		/// </summary>
		IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where, bool setAsNoTracking = false, params Expression<Func<TEntity, object>>[] includes);

		/// <summary>
		/// Finds entities based on provided criteria.
		/// </summary>
		IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where, bool setAsNoTracking = false);

		/// <summary>
		/// Finds entities based on provided criteria.
		/// </summary>
		IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where, string[] includes, bool setAsNoTracking = false);

		/// <summary>
		/// Finds one entity based on provided criteria.
		/// </summary>
		Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);

		/// <summary>
		/// Finds one entity based on provided criteria.
		/// </summary>
		Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> where,
										bool setAsNoTracking = false,
										params Expression<Func<TEntity, object>>[] includes);

		/// <summary>
		/// Finds one entity based on provided criteria.
		/// </summary>
		Task<TEntity> FindOneAsync(bool setAsNoTracking = false);

		/// <summary>
		/// Finds one entity based on its Identifier.
		/// </summary>
		Task<TEntity> FindByIdAsync(long id);

		/// <summary>
		/// Finds entities based on provided criteria.
		/// </summary>
		Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);

		/// <summary>
		/// Finds entities based on provided criteria.
		/// </summary>
		Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> where, bool setAsNoTracking = false, params Expression<Func<TEntity, object>>[] includes);

		/// <summary>
		/// Finds entities based on provided criteria.
		/// </summary>
		Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> where, bool setAsNoTracking = false);

		/// <summary>
		/// Finds entities based on provided criteria.
		/// </summary>
		Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> where, string[] includes, bool setAsNoTracking = false);
	}
}