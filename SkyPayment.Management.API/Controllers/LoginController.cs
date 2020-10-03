using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SkyPayment.Contract.RequestModel;
using SkyPayment.Core;

namespace SkyPayment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly Settings _settings;

        public LoginController(IOptions<Settings> settings)
        {
            _settings = settings.Value;
        }

        [Authorize]
        [HttpGet("Test")]
        public IActionResult TestAuth()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            /* Sadece test. Lütfen dalga geçmeyin.*/
            if (model.UserName == "user")
            {
                if (model.Password == "123")
                {
                    var token = GenerateJSONWebToken(model);
                    return Ok(new
                    {
                        token
                    });
                }
            }

            return new StatusCodeResult(418);
        }

        private string GenerateJSONWebToken(LoginModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Token.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_settings.Token.Issuer,
                _settings.Token.Issuer,
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}