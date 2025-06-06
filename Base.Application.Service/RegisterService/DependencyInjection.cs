using AutoMapper;
using Base.Application.Service.Interfaces.Contracts;
using Base.Application.Service.Interfaces.Implementation;
using Base.Application.Service.Mapping;
using Base.Domain.Entities;
using Base.Infraestructure.Data.Context;
using Base.Infraestructure.Data.Repositories.Contracts;
using Base.Infraestructure.Data.Repositories.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Application.Service.RegisterService
{
	public static class DependencyInjection
	{
		/// <summary>
		/// Adds the dependency injection.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="configuration">The configuration.</param>
		/// <returns></returns>
		public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
		{
			#region DataBaseConnection
			services.AddDbContext<DataBaseContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
			#endregion

			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new DomainToDtoMappingProfile());
			});

			IMapper mapper = mappingConfig.CreateMapper();
			services.AddSingleton(mapper);
			AddServices(services);
			AddRepository(services);

			return services;
		}

		/// <summary>
		/// Adds the services.
		/// </summary>
		/// <param name="services">The services.</param>
		private static void AddServices(IServiceCollection services)
		{
			//services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddScoped<IHotelService, HotelService>();
			services.AddScoped<IHabitacionService, HabitacionService>();
			services.AddScoped<IUserAccountService, UserAccountService>();
			services.AddScoped<IReservationService, ReservacionService>();
			services.AddScoped<IPersonaService, PersonaService>();
			services.AddScoped<ICiudadService, CiudadService>();
            services.AddScoped<ITourService, TourService>();

        }

		/// <summary>
		/// Adds the repository.
		/// </summary>
		/// <param name="services">The services.</param>
		private static void AddRepository(IServiceCollection services)
		{
			services.AddScoped<IHotelRepository, HotelRepository>();
			services.AddScoped<IHabitacionRepository, HabitacionRepository>();
			services.AddScoped<IAccountRepository, AccountRepository>();
			services.AddScoped<IReservacionRepository, ReservacionRepository>();
			services.AddScoped<IPersonaRepository, PersonaRepository>();
			services.AddScoped<ICiudadRepository, CiudadRepository>();
            services.AddScoped<ITourRepository, TourRepository>();
        }
	}
}
