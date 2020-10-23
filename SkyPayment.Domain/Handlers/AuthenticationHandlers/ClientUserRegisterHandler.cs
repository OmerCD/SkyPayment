using System.Threading;
using System.Threading.Tasks;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Domain.CQ.Commands.AuthenticationCommands;

namespace SkyPayment.Domain.Handlers.AuthenticationHandlers
{
    public class ClientUserRegisterHandler : IBaseRequestHandler<ClientUserRegisterCommand>
    {
        public Task<BaseResponseModel> Handle(ClientUserRegisterCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}