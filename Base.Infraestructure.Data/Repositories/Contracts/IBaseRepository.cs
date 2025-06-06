using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infraestructure.Data.Repositories.Contracts
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IBaseRepository<T> where T : class
	{
		/// <summary>
		/// Inserts the asynchronous.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		Task<int> InsertAsync(T entity);
		/// <summary>
		/// Updates the asynchronous.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		Task<int> UpdateAsync(T entity);
		/// <summary>
		/// Removes the asynchronous.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		Task<int> RemoveAsync(T entity);
		/// <summary>
		/// Removes the asynchronous.
		/// </summary>
		/// <param name="Id">The identifier.</param>
		/// <returns></returns>
		Task<int> RemoveAsync(int Id);
		/// <summary>
		/// Gets all asynchronous.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns></returns>
		Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
		/// <summary>
		/// Gets the single asynchronous.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns></returns>
		Task<T?> GetSingleAsync(Expression<Func<T, bool>>? filter = null);
	}
}
