using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyPaymentV2.CQ.Commands.Manager.Authentication;
using SkyPaymentV2.Manager.API.Models;

namespace SkyPaymentV2.User.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IdentityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(ManagerLoginRequestModel model)
        {
            var command = new ManagerLoginCommand()
            {
                UserName = model.UserName,
                Password = model.Password
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}