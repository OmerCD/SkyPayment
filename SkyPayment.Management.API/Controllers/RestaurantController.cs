using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Contract.RequestModel;
using SkyPayment.Domain.Queries;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IMediator mediator, IRestaurantService restaurantService)
        {
            _mediator = mediator;
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> GelAllRestaurant()
        {
            var identity = User.Identity as ClaimsIdentity;
            var value = identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var query = new GetAllRestaurantQuery(value);
            var send = await _mediator.Send(query);
            return Ok(send); 
        }

        [HttpPost]
        public IActionResult CreateRestaurant([FromBody] CreateRestaurantRequestModel createRestaurantRequestModel)
        {
            return Ok();
        }
    }
}