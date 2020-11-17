using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Contract.RequestModel.CustomerLogin;
using SkyPayment.Domain.CQ.Queries.AuthenticationQueries;
using SkyPayment.Management.API.Helper;

namespace SkyPayment.Client.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Login([Required] string userName, [Required] string password)
        {
            var query = new CustomerLoginQuery(userName, password);
            return await _mediator.Send(query).ToActionResult();
        }

        [HttpGet("test/customer")]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}