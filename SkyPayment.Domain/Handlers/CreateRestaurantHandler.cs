using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Domain.Command;

namespace SkyPayment.Domain.Handlers
{
    public class CreateRestaurantHandler:IRequestHandler<CreateRestaurantCommand,CreateRestaurantResponseModel>
    {
        public Task<CreateRestaurantResponseModel> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}