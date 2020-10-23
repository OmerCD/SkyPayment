using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Contract.RequestModel.Authentication;
using SkyPayment.Domain.CQ.Commands.AuthenticationCommands;
using SkyPayment.Management.API.Helper;

namespace SkyPayment.Client.API.Controllers
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
        public async Task<IActionResult> RegisterUser(UserRegisterCreateModel model)
        {
            var command = new ClientUserRegisterCommand(model.Email, model.Password, model.FirstName, model.LastName, model.TelephoneNumber);
            return await _mediator.ToActionResult(command);
        }
    }
}