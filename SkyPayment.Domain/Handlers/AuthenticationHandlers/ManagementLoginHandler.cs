using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SkyPayment.Contract.RequestModel;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Contract.ResponseModel.Authentication;
using SkyPayment.Core;
using SkyPayment.Domain.Queries.AuthenticationQueries;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.Domain.Handlers.AuthenticationHandlers
{
    public class ManagementLoginHandler : IBaseRequestHandler<ManagementLoginQuery>
    {
        private readonly IManagementAuthenticationService _managementAuthenticationService;
        private readonly Settings _settings;

        public ManagementLoginHandler(IManagementAuthenticationService managementAuthenticationService,
            IOptions<Settings> settings)
        {
            _managementAuthenticationService = managementAuthenticationService;
            _settings = settings.Value;
        }

        public Task<BaseResponseModel> Handle(ManagementLoginQuery request, CancellationToken cancellationToken)
        {
            var managementUser = _managementAuthenticationService.GetManagementUser(request.UserName);
            if (managementUser != null)
            {
                if (managementUser.Password == request.Password)
                {
                    return Task.FromResult(new BaseResponseModel
                    {
                        Data = new ManagementLoginResponseModel
                        {
                            Token = GenerateJsonWebToken(request.UserName),
                            ExpireTime = DateTime.Now.AddMinutes(120)
                        },
                        StatusCode = 200,
                        Description = "Başarılı Giriş"
                    });
                }
                else
                {
                    return Task.FromResult(new BaseResponseModel
                    {
                        StatusCode = 401,
                        Description = "Hatalı Giriş"
                    });
                }
            }
            else
            {
                return Task.FromResult(new BaseResponseModel
                {
                    StatusCode = 401,
                    Description = "Hatalı Giriş"
                });
            }
        }

        private string GenerateJsonWebToken(string userName)
        {
            var managementUser = _managementAuthenticationService.GetManagementUser(userName);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Token.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, managementUser.Id),
                new Claim(ClaimTypes.Role, managementUser.Role),
                new Claim(ClaimTypes.Name, managementUser.FullName), 
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