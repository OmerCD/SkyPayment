using MediatR;
using SkyPayment.Contract.ResponseModel;

namespace SkyPayment.Domain
{
    public interface IBaseRequestHandler<in T> : IRequestHandler<T, BaseResponseModel> where T : IRequest<BaseResponseModel>
    {
        
    }
}