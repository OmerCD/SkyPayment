using AutoMapper;
using SkyPayment.Contract.ResponseModel.Client;
using SkyPayment.Core.Entities;

namespace SkyPayment.Mappings
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerRegistrationSuccessViewModel>()
                .ForMember(model => model.FullName,
                    expression => expression.MapFrom(customer => $"{customer.Name} {customer.LastName}"));
        }
    }
}