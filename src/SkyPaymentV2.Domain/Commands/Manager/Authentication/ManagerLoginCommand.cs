using MediatR;

namespace SkyPaymentV2.CQ.Commands.Manager.Authentication
{
    public class ManagerLoginCommand : IRequest<ManagerLoginCommandResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class ManagerLoginCommandResponse
    {
        public string Token { get; set; }
    }
}