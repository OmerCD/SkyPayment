using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;
using MediatR;


namespace SkyPaymentV2.CQ.Commands
{
    public class UserLoginCommand : IRequest<UserLoginCommandResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserLoginCommandResponse
    {
        public string Token { get; set; }
    }
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, UserLoginCommandResponse>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserLoginCommandHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<UserLoginCommandResponse> Handle(UserLoginCommand request,
            CancellationToken cancellationToken)
        {
            var client = _httpClientFactory.CreateClient("IdentityServer");
            var disco = await client.GetDiscoveryDocumentAsync(cancellationToken: cancellationToken);
            if (disco.IsError)
            {
                throw new Exception();
            }

            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Password = request.Password,
                ClientSecret = @"mXRATs<#UF<QTp_'Z4PM~4`J;Qwkg-\v",
                UserName = request.UserName,
                ClientId = "customer",
                Scope = "userApi"
            }, cancellationToken);
            if (tokenResponse.IsError)
            {
                throw new Exception();
            }

            return new UserLoginCommandResponse()
            {
                Token = tokenResponse.AccessToken
            };
        }
    }
}