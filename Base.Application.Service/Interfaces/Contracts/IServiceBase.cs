using Base.Domain.DTO;
using Base.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Base.Application.Service.Interfaces.Contracts
{
	public interface IServiceBase<T, TDto> where T : class where TDto : BaseDTO
	{
		Task<ResponseHelper> GetAllAsync(Expression<Func<T, bool>>? filter = null);
		Task<ResponseHelper> InsertAsync(T entity);
		Task<ResponseHelper> UpdateAsync(T entity);
		Task<ResponseHelper> GetById(Expression<Func<T, bool>>? filter = null);
		Task<ResponseHelper> RemoveAsync(T entity);
		Task<ResponseHelper> RemoveAsync(int Id);
		Task<TDto> ConvertToDto(T entity);
        Task<T> ConvertToEntity(TDto dto);
        Task<List<TDto>> ConvertToDto(List<T> entity);
        Task<List<T>> ConvertToEntity(List<TDto> dto);
	}
}
