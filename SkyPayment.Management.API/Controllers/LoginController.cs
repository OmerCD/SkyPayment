using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SkyPayment.Contract.RequestModel;
using SkyPayment.Core;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly Settings _settings;
        private readonly IManagementAuthenticationService _managementAuthenticationService;

        public LoginController(IOptions<Settings> settings, IManagementAuthenticationService managementAuthenticationService)
        {
            _managementAuthenticationService = managementAuthenticationService;
            _settings = settings.Value;
        }

        [Authorize]
        [HttpGet("Test")]
        public IActionResult TestAuth()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            var managementUser = _managementAuthenticationService.GetManagementUser(loginModel.UserName);
            if (managementUser != null)
            {
                if (managementUser.Password == loginModel.Password)
                {
                    return Ok(GenerateJSONWebToken(loginModel));
                }
                else
                {
                    return Unauthorized("Password is wrong");
                }
            }
            else
            {
                return Unauthorized("User not found");
            }
        }
        [HttpPost]
        public IActionResult Register([FromBody]RegisterModel registerModel)
        {
            return Ok();
        }
    
        private string GenerateJSONWebToken(LoginModel userInfo)
        {
            var managementUser = _managementAuthenticationService.GetManagementUser(userInfo.UserName);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Token.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, managementUser.Id),
            };
            var token = new JwtSecurityToken(_settings.Token.Issuer,
                _settings.Token.Issuer,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
         
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}