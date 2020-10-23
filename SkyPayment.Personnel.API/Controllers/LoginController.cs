using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Management.API.Helper;
using SkyPayment.Contract.RequestModel;
using SkyPayment.Core;
using SkyPayment.Domain.CQ.Queries.AuthenticationQueries;

namespace SkyPayment.Personnel.API.Controllers
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

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var query = new PersonnelLoginQuery(loginModel.UserName, loginModel.Password);
            var response = await _mediator.Send(query);
            return response.ToActionResult();

        }
    }
}