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
    public class CiudadService: ServiceBase<Ciudad, CiudadDto>, ICiudadService
    {
        private readonly IMapper _mapper;
        private readonly ICiudadRepository _ciudadRepository;

        public CiudadService(IMapper mapper, ICiudadRepository ciudadRepository) : base(mapper, ciudadRepository) 
        { 
            _ciudadRepository = ciudadRepository;
            _mapper = mapper;
        }
    }
}
