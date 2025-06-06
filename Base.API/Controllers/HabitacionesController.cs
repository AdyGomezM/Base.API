using Base.Application.Service.Interfaces.Contracts;
using Base.Domain.DTO;
using Base.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers
{
    
	[Route("api/[controller]")]
	[ApiController]

    [Authorize]
    public class HabitacionesController : APIControllerBase<Habitacion,HabitacionDTO>
	{
        private readonly IHabitacionService _habitacionService;
        public HabitacionesController(IHabitacionService habitacionService):base(habitacionService) 
        {
            _habitacionService = habitacionService; 
        }
    }
}
