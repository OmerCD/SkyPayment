using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.API.Helper;
using SkyPayment.Contract.RequestModel;
using SkyPayment.Domain.Commands.AuthenticationCommands;

namespace SkyPayment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RegisterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterModel registerModel)
        {
            var command = new ManagementUserRegisterCommand(registerModel.Email,registerModel.Name,registerModel.Password, registerModel.LastName, registerModel.UserName);
            var response = await _mediator.Send(command);
            return response.ToActionResult();
        }

    }
}