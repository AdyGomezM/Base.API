using Base.Application.Service.Interfaces.Contracts;
using Base.Domain.DTO.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController(IUserAccountService userAccountService) : ControllerBase
	{
		[HttpPost("register")]
		public async Task<IActionResult> Register(UserDTO userDTO)
		{
			var response = await userAccountService.CreateAccount(userDTO);
			return Ok(response);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginDTO loginDTO)
		{
			var response = await userAccountService.LoginAccount(loginDTO);
			return Ok(response);
		}
	}
}
