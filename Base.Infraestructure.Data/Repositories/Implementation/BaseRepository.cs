using Base.Infraestructure.Data.Context;
using Dapper;
using ExpressionExtensionSQL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infraestructure.Data.Repositories.Implementation
{
	public class BaseRepository<T> where T : class
	{
		/// <summary>
		/// The context
		/// </summary>
		protected readonly DataBaseContext Context;
		/// <summary>
		/// The table name
		/// </summary>
		private string tableName;
		/// <summary>
		/// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public BaseRepository(DataBaseContext context)
		{
			Context = context;
			var model = context.Model;

			// Get all the entity types information contained in the DbContext class, ...
			var entityTypes = model.GetEntityTypes();

			// ... and get one by entity type information of "FooBars" DbSet property.
			var entityTypeOfFooBar = entityTypes.First(t => t.ClrType == typeof(T));
			var tableNameAnnotation = entityTypeOfFooBar.GetAnnotation("Relational:TableName");
			var tableNameOfFooBarSet = tableNameAnnotation.Value.ToString();
			tableName = tableNameOfFooBarSet;
		}

		/// <summary>
		/// Inserts the asynchronous.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		public virtual async Task<int> InsertAsync(T entity)
		{
			var properties = GetProperties(entity);
			var propertiesWithoutId = properties.Where(p => p.Name != "Id" && !p.GetAccessors().Any(x => x.IsVirtual)); // Excluye la propiedad "Id"
			var columnNames = string.Join(", ", propertiesWithoutId.Select(p => $"[{p.Name}]"));
			var parameterNames = string.Join(", ", propertiesWithoutId.Select(p => $"@{p.Name}"));
			var sql = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames}); SELECT CAST(SCOPE_IDENTITY() AS INT)";
			return await Context.Database.GetDbConnection().QuerySingleAsync<int>(sql, entity);
		}

		/// <summary>
		/// Updates the asynchronous.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		public virtual async Task<int> UpdateAsync(T entity)
		{
			var properties = GetProperties(entity);
			var propertiesWithoutId = properties.Where(p => p.Name != "Id" && !p.GetAccessors().Any(x => x.IsVirtual)); // Excluye la propiedad "Id"
			var updateColumns = propertiesWithoutId.Select(p => $"[{p.Name}] = @{p.Name}");
			var sql = $"UPDATE {tableName} SET {string.Join(", ", updateColumns)} WHERE Id = @Id";
			return await Context.Database.GetDbConnection().ExecuteAsync(sql, entity);
		}

		/// <summary>
		/// Removes the asynchronous.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		public virtual async Task<int> RemoveAsync(T entity)
		{
			var sql = "";

			// Borrado lógico: actualiza IsDeleted a true
			sql = $"UPDATE {tableName} SET IsDeleted = 1 WHERE Id = @Id";


			return await Context.Database.GetDbConnection().ExecuteAsync(sql, entity);
		}

		/// <summary>
		/// Removes the asynchronous.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public virtual async Task<int> RemoveAsync(int id)
		{
			var sql = "";

			// Borrado lógico: actualiza IsDeleted a true
			sql = $"UPDATE {tableName} SET IsDeleted = 1 WHERE Id = @Id";
			// Borrado físico
			//sql = $"DELETE FROM {tableName} WHERE Id = @Id";

			return await Context.Database.GetDbConnection().ExecuteAsync(sql, new { id });
		}

		/// <summary>
		/// Gets the properties.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		private IEnumerable<PropertyInfo> GetProperties(T entity)
		{
			// Obtiene todas las propiedades públicas de la entidad T que no sean de solo lectura.
			return entity.GetType()
				.GetProperties()
				.Where(p => p.CanWrite);
		}

		/// <summary>
		/// Gets all asynchronous.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns></returns>
		public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
		{
			var isDeletable = true;
			var sql = $"SELECT * FROM {tableName}";
			var parameters = new DynamicParameters();
			if (filter is null)
			{
				if (isDeletable)
				{
					sql += " WHERE IsDeleted = 0";
				}
			}
			else
			{
               
                var queryGenerated = filter.ToSql();// aqui se utiliza la libreria ExpressionExtensionSQL que es un conversor de lambda expresion to Sql
				string filterSql = queryGenerated.Sql;
                var className = typeof(T).Name;
                filterSql = filterSql.Replace(className, tableName);
                sql = $"SELECT * FROM {tableName} WHERE {filterSql}";
				if (isDeletable)
				{
					sql += " AND IsDeleted = 0";
				}
				foreach (var item in queryGenerated.Parameters)
				{
					parameters.Add(item.Key, item.Value);
				}
			}
			return (await Context.Database.GetDbConnection().QueryAsync<T>(sql, parameters)).ToList();
		}

		/// <summary>
		/// Gets the single asynchronous.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns></returns>
		public virtual async Task<T?> GetSingleAsync(Expression<Func<T, bool>>? filter = null)
		{
			var isDeletable = true;
			var sql = $"SELECT * FROM {tableName}";
			var parameters = new DynamicParameters();
			if (filter is null)
			{
				if (isDeletable)
				{
					sql += " WHERE IsDeleted = 0";
				}
			}
			else
			{
				
				var queryGenerated = filter.ToSql<T>();// aqui se utiliza la libreria ExpressionExtensionSQL que es un conversor de lambda expresion to Sql
				string filterSql = queryGenerated.Sql;
				var className = typeof(T).Name;
				filterSql = filterSql.Replace(className,tableName);
				sql = $"SELECT * FROM {tableName} WHERE {filterSql}";
				if (isDeletable)
				{
					sql += " AND IsDeleted = 0";
				}
				foreach (var item in queryGenerated.Parameters)
				{
					parameters.Add(item.Key, item.Value);
				}
			}
			return await Context.Database.GetDbConnection().QueryFirstOrDefaultAsync<T>(sql, parameters);
		}

		/// <summary>
		/// Gets the comparisonl operation.
		/// </summary>
		/// <param name="nodeType">Type of the node.</param>
		/// <returns></returns>
		private string GetComparisonlOperation(ExpressionType nodeType)
		{
			switch (nodeType)
			{
				case ExpressionType.Equal:
					return "=";
				case ExpressionType.NotEqual:
					return "<>";
				case ExpressionType.GreaterThan:
					return ">";
				case ExpressionType.GreaterThanOrEqual:
					return ">=";
				case ExpressionType.LessThan:
					return "<";
				case ExpressionType.LessThanOrEqual:
					return "<=";
				default:
					return null;
			}
		}

	}
}
