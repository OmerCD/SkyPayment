using SkyPayment.Core.BindingModel;
using SkyPayment.Core.Entities;
using SkyPayment.Infrastructure.Interface;

namespace SkyPayment.Infrastructure.Services
{
    public interface IPersonnelService : IService
    {
        PersonnelUser GetPersonnelUser(string userName);
        PersonnelUser CreatePersonnelUser(PersonnelBindingModel model);
        
    }
}