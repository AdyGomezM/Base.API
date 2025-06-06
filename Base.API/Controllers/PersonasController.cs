using Base.Application.Service.Interfaces.Contracts;
using Base.Domain.DTO;
using Base.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : APIControllerBase<Persona,PersonaDTO>
    {
        private readonly IPersonaService _personaService;
        public PersonasController(IPersonaService personaService):base(personaService)
        {
            _personaService = personaService; 
        }


        [HttpGet]
        public override async Task<ActionResult<List<PersonaDTO>>> GetAll()
        {
            var result = await _personaService.GetAllAsync(x => x.RFC != null);

            return Ok(result);  
        }
    }
    
}
