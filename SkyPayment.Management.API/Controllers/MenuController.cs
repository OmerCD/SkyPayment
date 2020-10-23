using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Management.API.Helper;
using SkyPayment.Contract.RequestModel;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Core.Entities;
using SkyPayment.Domain.CQ.Commands.MenuCommand;
using SkyPayment.Domain.CQ.Queries.MenuQueries;
using SkyPayment.Domain.Helpers;
using SkyPayment.Infrastructure.Interface;
using SkyPayment.Repository.Interfaces;

namespace SkyPayment.Management.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MenuController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu([FromBody]CreateMenuRequestModel menuRequest)
        {
            var managementUserId = User.GetManagementUserId();
            var command = new MenuCreateCommand(menuRequest.Name, menuRequest.CreateDateTime, managementUserId);
            var response = await _mediator.Send(command);
            return response.ToActionResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenus()
        {
            var managementUserId = User.GetManagementUserId();
            var query = new GetAllMenuQueries(managementUserId);
            var send = await _mediator.Send(query);
            return send.ToActionResult();
        }
        
     
        [HttpGet("{menuId}")]
        public async Task<IActionResult> GetById(string menuId)
        {
            var managementUserId = User.GetManagementUserId();
            var query=new GetByIdMenuQuery(managementUserId,menuId);
            var response = await _mediator.Send(query);
            return response.ToActionResult();
        }
        [HttpDelete("{menuId}")]
        public async Task<IActionResult> DeleteRestaurant(string menuId)
        {
            // var managementUserId = User.GetManagementUserId();
            // var command = new DeleteRestaurantCommand(managementUserId, restaurantId);
            // return (await _mediator.Send(command)).ToActionResult();
            var managementUserId = User.GetManagementUserId();
            return Ok();
        }
    }
}