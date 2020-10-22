using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Contract.ResponseModel.Authentication;
using SkyPayment.Core.Entities;
using SkyPayment.Domain.CQ.Commands.AuthenticationCommands;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.Domain.Handlers.AuthenticationHandlers
{
    public class PersonnelRegisterHandler : IBaseRequestHandler<PersonnelUserRegisterCommand>
    {
        private readonly IManagementAuthenticationService _managementAuthenticationService;
        private readonly IMapper _mapper;

        public PersonnelRegisterHandler(IManagementAuthenticationService managementAuthenticationService, IMapper mapper)
        {
            _managementAuthenticationService = managementAuthenticationService;
            _mapper = mapper;
        }

        public Task<BaseResponseModel> Handle(PersonnelUserRegisterCommand request, CancellationToken cancellationToken)
        {
            var entity = new PersonnelUser
            {
                Email = request.Email,
                Name = request.Name,
                Password = request.Password,
                CreateDate = DateTime.Now,
                LastName = request.LastName,
                RestaurantId = request.RestaurantId,
                UserName = request.UserName,
                ManagementUserId = request.ManagementUserId,
                NormalizedUserName = request.UserName.Trim().ToUpper()
            };
            var personnelUser = _managementAuthenticationService.CreatePersonnelUser(entity);
            return Task.FromResult(new BaseResponseModel
            {
                Data = _mapper.Map<PersonnelRegisterViewModel>(personnelUser),
                Description = "Personel Kayıdı",
                StatusCode = 201
            });
        }
    }
}