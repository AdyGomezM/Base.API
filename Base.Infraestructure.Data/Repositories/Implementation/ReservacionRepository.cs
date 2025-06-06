using Base.Domain.Entities;
using Base.Domain.ViewModels;
using Base.Infraestructure.Data.Context;
using Base.Infraestructure.Data.Repositories.Contracts;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infraestructure.Data.Repositories.Implementation
{
    public class ReservacionRepository : BaseRepository<Reservacion>, IReservacionRepository
    {
        public ReservacionRepository(DataBaseContext context) : base(context)
        {

        }


        public async Task<List<ReservacionHotelVM>> ObtenerListaCompleta()
        {
            string sql = $"select ho.Name as 'Hotel'," +
                $"h.Name as 'Habitacion'," +
                $"r.FechaInicio," +
                $"r.FechaFin," +
                $"r.CantidadPersonas," +
                $"p.Nombre as 'Huesped'" +
                $"from Reservaciones as r inner join Habitaciones as h on (r.IdHabitacion = h.Id)" +
                $"inner join Hoteles as ho on (h.IdHotel = ho.Id)" +
                $"inner join Personas as p on (r.idPersona = p.Id)";

            var result = await Context.Database.GetDbConnection().QueryAsync<ReservacionHotelVM>(sql);

            return result.ToList(); 

        }
    }
}
