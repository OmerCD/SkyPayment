using MediatR;
using SkyPayment.Contract.ResponseModel;

namespace SkyPayment.Domain
{
    public interface IBaseRequest : IRequest<BaseResponseModel>{}
}