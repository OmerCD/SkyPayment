using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Domain.Commands.RestaurantCommand;
using SkyPayment.Domain.Queries.RestaurantQueries;
using SkyPayment.Shared.Restaurant;

namespace SkyPayment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController:ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{userId}")]

        public async Task<IActionResult> GetAllRestaurant(string userId)
        {
            var getAllRestaurantQueries = new GetAllRestaurantQueries(userId);
            var send =await _mediator.Send(getAllRestaurantQueries);
            return Ok(send);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] RestaurantCreateModel restaurantCreateModel)
        {
            var restaurantCreateCommand = new RestaurantCreateCommand(restaurantCreateModel.Name, restaurantCreateModel.Address,
                restaurantCreateModel.PhoneNumber, restaurantCreateModel.FaxNumber, restaurantCreateModel.Email,
                restaurantCreateModel.Website, restaurantCreateModel.ManagementUserId, restaurantCreateModel.TableCount,
                restaurantCreateModel.Link, restaurantCreateModel.IsActive);
            var send = await _mediator.Send(restaurantCreateCommand);
            return Ok(send);
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteRestaurant(string id)
        {
            var restaurantDeleteCommand = new RestaurantDeleteCommand(id);
            var send = await _mediator.Send(restaurantDeleteCommand);
            return Ok(send);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRestaurant([FromBody] RestaurantUpdateModel restaurantUpdateModel)
        {
            return Ok();
        }
    }
}