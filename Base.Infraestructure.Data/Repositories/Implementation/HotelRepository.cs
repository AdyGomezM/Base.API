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
	public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
	{
		public HotelRepository(DataBaseContext context) : base(context)
		{
		}
	}
}
