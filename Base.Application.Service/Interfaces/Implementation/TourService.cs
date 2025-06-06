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
    public class TourService: ServiceBase<Tour, TourDTO>, ITourService
    {
        private readonly IMapper _mapper;
        private readonly ITourRepository _tourRepository;

        public TourService(IMapper mapper, ITourRepository tourRepository) : base(mapper, tourRepository) 
        { 
            _tourRepository = tourRepository;
            _mapper = mapper;
        }
    }
}
