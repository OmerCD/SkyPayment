using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SkyPayment.API.Helper;
using SkyPayment.Contract.RequestModel;
using SkyPayment.Core;
using SkyPayment.Domain.Queries.AuthenticationQueries;

namespace SkyPayment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly Settings _settings;
        private readonly IMediator _mediator;
        public LoginController(IOptions<Settings> settings, IMediator mediator)
        {
            _mediator = mediator;
            _settings = settings.Value;
        }

        [Authorize(Policy = "ManagementRole")]
        [HttpGet("test/management")]
        public IActionResult TestManagementAuth()
        {
            return Ok();
        }
        [Authorize(Policy = "PersonnelRole")]
        [HttpGet("test/personnel")]
        public IActionResult TestPersonnelAuth()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var query = new ManagementLoginQuery(loginModel.Password, loginModel.UserName);
            var response = await _mediator.Send(query);
            return response.ToActionResult();
        }
    }
}