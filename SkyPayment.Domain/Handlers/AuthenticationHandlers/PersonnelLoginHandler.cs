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
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.Domain.Handlers.AuthenticationHandlers
{
    public class PersonnelLoginHandler : IBaseRequestHandler<PersonnelLoginQuery>
    {
        private readonly IPersonnelService _personnelService;
        private readonly Settings _settings;

        public PersonnelLoginHandler(IPersonnelService personnelService, IOptions<Settings> settings)
        {
            _personnelService = personnelService;
            _settings = settings.Value;
        }

        public Task<BaseResponseModel> Handle(PersonnelLoginQuery request, CancellationToken cancellationToken)
        {
            var personnelUser = _personnelService.GetPersonnelUser(request.UserName);
            if (personnelUser == null)
                return Task.FromResult(new BaseResponseModel
                {
                    StatusCode = 401,
                    Description = "Hatalı Giriş"
                });
            if (personnelUser.Password == request.Password)
            {
                return Task.FromResult(new BaseResponseModel
                {
                    Data = new PersonnelLoginResponseModel
                    {
                        Token = GenerateJsonWebToken(request.UserName),
                        ExpireTime = DateTime.Now.AddMinutes(120)
                    },
                    StatusCode = 200,
                    Description = "Başarılı Giriş!"
                });
            }

            return Task.FromResult(new BaseResponseModel
            {
                StatusCode = 401,
                Description = "Hatalı Giriş"
            });
        }

        private string GenerateJsonWebToken(string userName)
        {
            var managementUser = _personnelService.GetPersonnelUser(userName);
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