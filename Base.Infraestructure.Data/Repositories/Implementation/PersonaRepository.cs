using Base.Domain.Entities;
using Base.Infraestructure.Data.Context;
using Base.Infraestructure.Data.Repositories.Contracts;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infraestructure.Data.Repositories.Implementation
{
    public class PersonaRepository : BaseRepository<Persona>, IPersonaRepository
    {
        public PersonaRepository(DataBaseContext context) : base(context)
        {
            
        }

        public async Task<bool> ExisteNombre(string nombre)
        {
            string sql = $"SELECT count(*) FROM Personas where Nombre = '{nombre}'";
            var result = await Context.Database.GetDbConnection().QueryFirstOrDefaultAsync<int>(sql);

            return result > 0 ? true : false;
        }

    }
}
