using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.API.Helper;
using SkyPayment.Contract.RequestModel;
using SkyPayment.Domain.Command;
using SkyPayment.Domain.Helpers;
using SkyPayment.Domain.Queries;
using SkyPayment.Domain.Queries.RestaurantQueries;
using SkyPayment.Infrastructure.Interface;
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

        [HttpGet("{restaurantId}")]
        public async Task<IActionResult> GetRestaurantById(string restaurantId)
        {
            var managementUserId = User.GetManagementUserId();
            var query = new GetRestaurantByIdQuery(managementUserId, restaurantId);
            var response = await _mediator.Send(query);
            return response.ToActionResult();
        }

        [HttpDelete("{restaurantId}")]
        public async Task<IActionResult> DeleteRestaurant(string restaurantId)
        {
            var managementUserId = User.GetManagementUserId();
            var command = new DeleteRestaurantCommand(managementUserId, restaurantId);
            return (await _mediator.Send(command)).ToActionResult();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantRequestModel createRestaurantRequestModel)
        {
            // var command = new ManagementUserRegisterCommand(registerModel.Email,registerModel.Name,registerModel.Password, registerModel.LastName, registerModel.UserName);
            // var response = await _mediator.Send(command);
            // return response.ToActionResult();
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var command = new CreateRestaurantCommand(createRestaurantRequestModel.Name,
                createRestaurantRequestModel.Address, createRestaurantRequestModel.PhoneNumber,
                createRestaurantRequestModel.FaxNumber,
                createRestaurantRequestModel.Email, createRestaurantRequestModel.Website,  
                claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value,createRestaurantRequestModel.TableCount,createRestaurantRequestModel.Link);
            var response = await _mediator.Send(command);
            return response.ToActionResult();
        }
    }
}