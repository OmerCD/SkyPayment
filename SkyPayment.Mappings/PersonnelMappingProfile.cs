using AutoMapper;
using SkyPayment.Contract.RequestModel.Authentication;
using SkyPayment.Contract.ResponseModel.Authentication;
using SkyPayment.Contract.ResponseModel.Personnel;
using SkyPayment.Core.Entities;
using SkyPayment.Domain.CQ.Commands.AuthenticationCommands;

namespace SkyPayment.Mappings
{
    public class PersonnelMappingProfile : Profile
    {
        public PersonnelMappingProfile()
        {
            CreateMap<PersonnelUser, PersonnelRegisterViewModel>()
                .ForMember(x => x.FullName, expression => expression.MapFrom(user => user.Name + ' ' + user.LastName));
            CreateMap<PersonnelRegisterCreateModel, PersonnelUserRegisterCommand>();
            CreateMap<PersonnelUser, PersonnelViewModel>();
        }
    }
}