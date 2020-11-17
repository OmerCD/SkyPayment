using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Contract.ResponseModel.Client;
using SkyPayment.Core.Entities;
using SkyPayment.Domain.CQ.Commands.AuthenticationCommands;
using SkyPayment.Infrastructure.Interface;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.Domain.Handlers.AuthenticationHandlers
{
    public class ClientUserRegisterHandler : IBaseRequestHandler<ClientUserRegisterCommand>
    {
        private readonly ICustomerService _customerService;
        private readonly ISecurePasswordHasherService _securePasswordHasherService;
        private readonly IMapper _mapper;

        public ClientUserRegisterHandler(ICustomerService customerService, ISecurePasswordHasherService securePasswordHasherService, IMapper mapper)
        {
            _customerService = customerService;
            _securePasswordHasherService = securePasswordHasherService;
            _mapper = mapper;
        }

        public Task<BaseResponseModel> Handle(ClientUserRegisterCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.Now;
            Customer customer;
            var normalizedUserName = request.UserName.Trim().ToLower();
            customer = _customerService.GetCustomer(x => x.Email == request.Email);
            if (customer != null)
            {
                return Task.FromResult(new BaseResponseModel
                {
                    StatusCode = 200,
                    IsError = true,
                    Description = "Email zaten kullanılmakta"
                });
            }
            customer = _customerService.GetCustomer(x => x.NormalizedUserName == normalizedUserName);
            if (customer != null)
            {
                return Task.FromResult(new BaseResponseModel
                {
                    StatusCode = 200,
                    IsError = true,
                    Description = "Kullanıcı Adı zaten kullanılmakta"
                });
            }

            customer = _customerService.GetCustomer(x => x.PhoneNumber == request.TelephoneNumber);
            if (customer != null)
            {
                return Task.FromResult(new BaseResponseModel
                {
                    StatusCode = 200,
                    IsError = true,
                    Description = "Telefon Numarası zaten kullanikmakta"
                });
            }
            var entity = new Customer()
            {
                Email = request.Email,
                Name = request.FirstName,
                Password = _securePasswordHasherService.Hash(request.Password),
                IsDeleted = false,
                CreateDate = now,
                PhoneNumber = request.TelephoneNumber,
                LastName = request.LastName,
                UserName = request.UserName,
                NormalizedUserName = normalizedUserName
            };
            customer = _customerService.CreateCustomer(entity);
            return Task.FromResult(new BaseResponseModel()
            {
                Data = _mapper.Map<CustomerRegistrationSuccessViewModel>(customer),
                Description = "Kullanıcı oluşturuldu",
                StatusCode = 201
            });
        }
    }
}