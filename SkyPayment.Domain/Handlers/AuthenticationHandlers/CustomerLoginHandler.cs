using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Contract.ResponseModel.Authentication;
using SkyPayment.Core;
using SkyPayment.Domain.CQ.Queries.AuthenticationQueries;
using SkyPayment.Infrastructure.Interface;

namespace SkyPayment.Domain.Handlers.AuthenticationHandlers
{
    public class CustomerLoginHandler : IBaseRequestHandler<CustomerLoginQuery>
    {
        private readonly ICustomerService _customerService;
        private readonly Settings _settings;

        public CustomerLoginHandler(ICustomerService customerService,IOptions<Settings> settings)
        {
            _customerService = customerService;
            _settings = settings.Value;
        }

        public Task<BaseResponseModel> Handle(CustomerLoginQuery request, CancellationToken cancellationToken)
        {
            if (_customerService.CheckLoginInfo(request.UserName, request.Password))
            {
                return Task.FromResult(new BaseResponseModel()
                {
                    Data = new CustomerLoginResponseModel
                    {
                        Token = GenerateJsonWebToken(request.UserName.Trim().ToLower())
                    },
                    StatusCode = 200,
                    Description = "Başarılı Giriş"
                });
            }

            return Task.FromResult(new BaseResponseModel()
            {
                StatusCode = 401
            });
        }
        private string GenerateJsonWebToken(string userName)
        {
            var customer = _customerService.GetCustomer(x=>x.NormalizedUserName == userName.Trim().ToLower());
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Token.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, customer.Id),
                new Claim(ClaimTypes.Role, customer.Role),
                new Claim(ClaimTypes.Name, customer.FullName), 
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