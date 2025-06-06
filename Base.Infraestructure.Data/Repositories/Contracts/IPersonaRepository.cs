using Base.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infraestructure.Data.Repositories.Contracts
{
    public interface IPersonaRepository : IBaseRepository<Persona>
    {
        Task<bool> ExisteNombre(string nombre);
    }
}
