using Base.Domain.Entities;
using Base.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infraestructure.Data.Repositories.Contracts
{
    public interface IReservacionRepository : IBaseRepository<Reservacion>
    {
        Task<List<ReservacionHotelVM>> ObtenerListaCompleta();
    }
}
