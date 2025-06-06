using Base.Domain.DTO;
using Base.Domain.Entities;
using Base.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Application.Service.Interfaces.Contracts
{
    public interface IReservationService : IServiceBase<Reservacion, ReservacionDTO>
    {
        Task<List<ReservacionHotelVM>> ObtenerListaCompleta();
    }
}
