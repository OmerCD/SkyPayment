using SkyPayment.Core.BindingModel;
using SkyPayment.Core.Entities;

namespace SkyPayment.Infrastructure.Services
{
    public interface IPersonnelService
    {
        PersonnelUser GetPersonnelUser(string userName);
        PersonnelUser CreatePersonnelUser(PersonnelBindingModel model);
        
    }
}