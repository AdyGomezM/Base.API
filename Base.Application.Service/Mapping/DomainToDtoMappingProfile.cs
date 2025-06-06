using AutoMapper;
using Base.Domain.DTO;
using Base.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Application.Service.Mapping
{
	public class DomainToDtoMappingProfile : Profile
	{
        public DomainToDtoMappingProfile()
        {

			this.CreateMap<EntityBase, BaseDTO>();
			this.CreateMap<HabitacionDTO, Habitacion>().ReverseMap();
			this.CreateMap<HotelDTO, Hotel>().ReverseMap();
			this.CreateMap<ReservacionDTO, Reservacion>().ReverseMap();
			this.CreateMap<PersonaDTO, Persona>().ReverseMap();
			this.CreateMap<CiudadDto, Ciudad>().ReverseMap();
		}
    }
}
