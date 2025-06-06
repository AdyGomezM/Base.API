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
    public class TourController : APIControllerBase<Tour, TourDTO>
    {
        private readonly ITourService _tourService;
        public TourController(ITourService tourService) : base(tourService)
        {
            _tourService = tourService;
        }
    }
}
