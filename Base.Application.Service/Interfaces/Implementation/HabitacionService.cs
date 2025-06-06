using AutoMapper;
using Base.Application.Service.Interfaces.Contracts;
using Base.Domain.DTO;
using Base.Domain.Entities;
using Base.Infraestructure.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Application.Service.Interfaces.Implementation
{
	public class HabitacionService : ServiceBase<Habitacion,HabitacionDTO>, IHabitacionService
	{
		private readonly IMapper _mapper;
		private IHabitacionRepository _habitacionRepository;
		public HabitacionService(IMapper mapper, IHabitacionRepository habitacionRepository) : base(mapper,habitacionRepository)
        {
            _habitacionRepository = habitacionRepository;
			_mapper = mapper;	
        }
    }
}
