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
	public class HotelService : ServiceBase<Hotel, HotelDTO>, IHotelService
	{
		private readonly IMapper _mapper;
		private readonly IHotelRepository _repository;
		public HotelService(IMapper mapper, IHotelRepository repository)
			: base(mapper, repository)
		{
			_mapper = mapper;
			_repository = repository;
		}
	}
}
