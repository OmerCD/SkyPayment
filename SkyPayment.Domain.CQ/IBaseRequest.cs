using MediatR;
using SkyPayment.Contract.ResponseModel;

namespace SkyPayment.Domain.CQ
{
    public interface IBaseRequest : IRequest<BaseResponseModel>{}
}