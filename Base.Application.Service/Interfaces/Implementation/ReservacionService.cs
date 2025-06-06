using AutoMapper;
using Base.Application.Service.Interfaces.Contracts;
using Base.Domain.DTO;
using Base.Domain.Entities;
using Base.Domain.ViewModels;
using Base.Infraestructure.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Application.Service.Interfaces.Implementation
{
    public class ReservacionService : ServiceBase<Reservacion, ReservacionDTO>, IReservationService
    {
        private readonly IMapper _mapper;
        private readonly IReservacionRepository _repository;
        public ReservacionService(IMapper mapper, IReservacionRepository repository)
            : base(mapper, repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<ReservacionHotelVM>> ObtenerListaCompleta()
        {
            List<ReservacionHotelVM> lista = new List<ReservacionHotelVM>();
            try
            {
                lista = await _repository.ObtenerListaCompleta();
            }
            catch (Exception e)
            {
                lista = null;
            }

            return lista;
        }
    }
}
