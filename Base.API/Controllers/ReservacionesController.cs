using Base.Application.Service.Interfaces.Contracts;
using Base.Domain.DTO;
using Base.Domain.Entities;
using Base.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservacionesController : APIControllerBase<Reservacion,ReservacionDTO>
    {
        private readonly IReservationService _reservacionService;
        public ReservacionesController(IReservationService reservacionService):base(reservacionService)
        {
            _reservacionService = reservacionService; 
        }

        [HttpGet]
        [Route("ObtenerListaCompleta")]
        public async Task<ActionResult<List<ReservacionHotelVM>>> ObtenerListaCompleta()
        {
            var lista = await _reservacionService.ObtenerListaCompleta();

            return Ok(lista);
        }
    }
}
