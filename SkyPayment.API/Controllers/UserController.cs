using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Domain.Handler.User;
using SkyPayment.Shared.User;

namespace SkyPayment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController :ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateModel userCreateModel)
        {
            var userCreateCommand = new UserCreateCommand(userCreateModel.Name, userCreateModel.LastName, userCreateModel.UserName,
                userCreateModel.Email, userCreateModel.Phone);
            var send = await _mediator.Send(userCreateCommand);
            return Ok(send);
        }
    }
}