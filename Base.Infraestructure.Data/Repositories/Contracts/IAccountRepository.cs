using Base.Domain.DTO.Security;
using Base.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infraestructure.Data.Repositories.Contracts
{
	public interface IAccountRepository
	{
		Task<ResponseHelper> CreateAccount(UserDTO userDTO);
		Task<ResponseHelper> LoginAccount(LoginDTO loginDTO);
	}
}
