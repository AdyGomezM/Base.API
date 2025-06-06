using Base.Application.Service.Interfaces.Contracts;
using Base.Domain.DTO;
using Base.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HotelsController : APIControllerBase<Hotel, HotelDTO>
	{
		private readonly IHotelService _service;
		public HotelsController(IHotelService service)
			 : base(service)
		{
			_service = service;
		}

		
	}
}
