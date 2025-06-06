using Base.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infraestructure.Data.Context
{
	public class DataBaseContext : IdentityDbContext<ApplicationUser>
	{
		public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			var entitiesAssembly = typeof(EntityBase).Assembly;
			modelBuilder.RegisterAllEntities<EntityBase>(entitiesAssembly);
			new DbInitializer(modelBuilder).Seed();
		}
	}
}
