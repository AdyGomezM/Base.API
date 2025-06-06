using Base.Domain.Entities;
using Base.Infraestructure.Data.Context;
using Base.Infraestructure.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infraestructure.Data.Repositories.Implementation
{
    public class CiudadRepository : BaseRepository<Ciudad>, ICiudadRepository
    {
        public CiudadRepository(DataBaseContext context):base(context) { }
    }
}
