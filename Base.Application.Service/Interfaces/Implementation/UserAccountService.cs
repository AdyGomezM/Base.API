using Base.Application.Service.Interfaces.Contracts;
using Base.Domain.DTO.Security;
using Base.Domain.ViewModels;
using Base.Infraestructure.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Application.Service.Interfaces.Implementation
{
	public class UserAccountService (IAccountRepository accountRepository) : IUserAccountService
	{
		public async Task<ResponseHelper> CreateAccount(UserDTO userDTO)
		{
			ResponseHelper response = new ResponseHelper();
			try
			{
				response = await accountRepository.CreateAccount(userDTO);
			}
			catch (Exception e)
			{
				response.Message = e.Message;
			}
			return response;
		}

		public async Task<ResponseHelper> LoginAccount(LoginDTO loginDTO)
		{
			ResponseHelper response = new ResponseHelper();
			try
			{
				response = await accountRepository.LoginAccount(loginDTO);
			}
			catch (Exception e)
			{
				response.Message = e.Message;
			}
			return response;
		}
	}
}
