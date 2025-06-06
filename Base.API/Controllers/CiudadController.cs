using Base.Application.Service.Interfaces.Contracts;
using Base.Domain.DTO;
using Base.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //[Authorize]
    public class CiudadController : APIControllerBase<Ciudad, CiudadDto>
    {
        private readonly ICiudadService _ciudadService;
        public CiudadController(ICiudadService ciudadService) : base(ciudadService)
        {
            _ciudadService = ciudadService;
        }
    }
}
