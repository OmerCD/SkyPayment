using SkyPayment.Contract.RequestModel;
using SkyPayment.Contract.ResponseModel;

namespace SkyPayment.Infrastructure.Interface
{
    public interface IMenuService
    {
        public CreateMenuResponseModel Add(CreateMenuRequestModel model);
    }
}