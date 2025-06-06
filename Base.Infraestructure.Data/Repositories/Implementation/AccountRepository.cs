using Base.Domain.DTO.Security;
using Base.Domain.Entities;
using Base.Domain.ViewModels;
using Base.Infraestructure.Data.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infraestructure.Data.Repositories.Implementation
{
	public class AccountRepository(

		UserManager<ApplicationUser> userManager,
		RoleManager<IdentityRole> roleManager,
		IConfiguration config)
		: IAccountRepository
	{
		public async Task<ResponseHelper> CreateAccount(UserDTO userDTO)
		{
			if (userDTO is null) return new ResponseHelper() { Success = false, Message = "sin datos"};
			var newUser = new ApplicationUser()
			{
				Name = userDTO.Name,
				Email = userDTO.Email,
				PasswordHash = userDTO.Password,
				UserName = userDTO.Email
			};
			var user = await userManager.FindByEmailAsync(newUser.Email);
			if (user is not null) return new ResponseHelper() { Success = false, Message = "Usuario ya se encuentra registrado" }; ;

			var createUser = await userManager.CreateAsync(newUser!, userDTO.Password);
			if (!createUser.Succeeded) return new ResponseHelper() { Success = false, Message = "ocurrió un error"}; ;

			//Assign Default Role : Admin to first registrar; rest is user
			var checkAdmin = await roleManager.FindByNameAsync("Admin");
			if (checkAdmin is null)
			{
				await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
				await userManager.AddToRoleAsync(newUser, "Admin");
				return new ResponseHelper() { Success = true, Message = "Cuenta creada con éxito." };
			}
			else
			{
				var checkUser = await roleManager.FindByNameAsync("User");
				if (checkUser is null)
					await roleManager.CreateAsync(new IdentityRole() { Name = "User" });

				await userManager.AddToRoleAsync(newUser, "User");
				return new ResponseHelper() { Success = true, Message = "Cuenta creada" };
			}
		}

		public async Task<ResponseHelper> LoginAccount(LoginDTO loginDTO)
		{
			if (loginDTO == null)
				return new ResponseHelper() { Success = false, Message = "NO se encuentran los datos" };

			var getUser = await userManager.FindByEmailAsync(loginDTO.Email);
			if (getUser is null)
				return new ResponseHelper() { Success = false, Message = "Usuario no encontrado" };

			bool checkUserPasswords = await userManager.CheckPasswordAsync(getUser, loginDTO.Password);
			if (!checkUserPasswords)
				return new ResponseHelper() { Success = false, Message = "Usuario o contraseña incorrectos" };

			var getUserRole = await userManager.GetRolesAsync(getUser);
			var userSession = new UserSession(getUser.Id, getUser.Name, getUser.Email, getUserRole.First());
			string token = GenerateToken(userSession);
			return new ResponseHelper() { Success = true, Message = "Acceso correcto", Data = token };
		}

		private string GenerateToken(UserSession user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var userClaims = new[]
			{
				new Claim(ClaimTypes.NameIdentifier, user.Id),
				new Claim(ClaimTypes.Name, user.Name),
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.Role, user.Role)
			};
			var token = new JwtSecurityToken(
				issuer: config["Jwt:Issuer"],
				audience: config["Jwt:Audience"],
				claims: userClaims,
				expires: DateTime.Now.AddDays(1),
				signingCredentials: credentials
				);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
