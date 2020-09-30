using System.Collections.Generic;
using SkyPayment.Contract.RequestModel;
using SkyPayment.Contract.ResponseModel;

namespace SkyPayment.Infrastructure.Interface
{
    public interface IMenuService : IService
    {
        CreateMenuResponseModel Add(CreateMenuRequestModel model);
        IEnumerable<MenuResponseModel> GetAll();
    }
}