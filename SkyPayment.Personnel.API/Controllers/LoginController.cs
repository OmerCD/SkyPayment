using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.API.Helper;
using SkyPayment.Contract.RequestModel;
using SkyPayment.Core;
using SkyPayment.Domain.Queries.AuthenticationQueries;

namespace SkyPayment.Personnel.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly Settings _settings;
        private readonly IMediator _mediator;

        public LoginController(Settings settings, IMediator mediator)
        {
            _settings = settings;
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