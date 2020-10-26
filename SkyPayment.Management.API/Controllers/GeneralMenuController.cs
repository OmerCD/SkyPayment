using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Contract.RequestModel;
using SkyPayment.Domain.CQ.Commands.GeneralMenuCommand;
using SkyPayment.Domain.Helpers;
using SkyPayment.Management.API.Helper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkyPayment.Management.API.Controllers
{
    [Route("api/[controller]")]
    public class GeneralMenuController : Controller
    {
        private readonly IMediator _mediator;

        public GeneralMenuController(IMediator mediator)
        {
            _mediator = mediator;
        }


        //[HttpPost]
        //public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantRequestModel createRestaurantRequestModel)
        //{
        //    
        //    var claimsIdentity = User.Identity as ClaimsIdentity;
        //    var command = new CreateRestaurantCommand(createRestaurantRequestModel.Name,
        //        createRestaurantRequestModel.Address, createRestaurantRequestModel.PhoneNumber,
        //        createRestaurantRequestModel.FaxNumber,
        //        createRestaurantRequestModel.Email, createRestaurantRequestModel.Website,
        //        claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value, createRestaurantRequestModel.TableCount, createRestaurantRequestModel.Link);
        //    var response = await _mediator.Send(command);
        //    return response.ToActionResult();
        //}
        [HttpPost]
        public async Task<IActionResult> CreateMenu([FromBody] ManagementUserMenuRequestModel createManagementUserMenu)
        {
            var command = new CreateUserMenuCommand(createManagementUserMenu.Name, User.GetManagementUserId()
                , createManagementUserMenu.Type);
            var response = await _mediator.Send(command);
            return response.ToActionResult();
        }
    }
}