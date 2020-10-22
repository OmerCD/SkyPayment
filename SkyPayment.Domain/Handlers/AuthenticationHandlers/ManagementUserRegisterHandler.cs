using System.Threading;
using System.Threading.Tasks;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Core.BindingModel;
using SkyPayment.Domain.CQ.Commands.AuthenticationCommands;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.Domain.Handlers.AuthenticationHandlers
{
    public class ManagementUserRegisterHandler : IBaseRequestHandler<ManagementUserRegisterCommand>
    {
        private readonly IManagementAuthenticationService _managementAuthenticationService;

        public ManagementUserRegisterHandler(IManagementAuthenticationService managementAuthenticationService)
        {
            _managementAuthenticationService = managementAuthenticationService;
        }

        public Task<BaseResponseModel> Handle(ManagementUserRegisterCommand request, CancellationToken cancellationToken)
        {
            var managementUser = _managementAuthenticationService.CreateManagementUser(new ManagementBindingModel
            {
                Email = request.Email,
                Name = request.Name,
                Password = request.Password,
                LastName = request.LastName,
                UserName = request.UserName
            });

            if (managementUser != null)
            {
                return Task.FromResult<BaseResponseModel>(new BaseResponseModel
                {
                    Description = "Kayıt Başarılı",
                    StatusCode = 201
                });
            }
            return Task.FromResult<BaseResponseModel>(new BaseResponseModel
            {
                Description = "Bir hata oluştu",
                StatusCode = 400
            });
        }
    }
}