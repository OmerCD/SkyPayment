using SkyPayment.Core.BindingModel;
using SkyPayment.Core.Entities;
using SkyPayment.Infrastructure.Interface;

namespace SkyPayment.Infrastructure.Services
{
    public interface IManagementAuthenticationService : IService
    {
        public ManagementUser GetManagementUser(string userName);

        ManagementUser CreateManagementUser(ManagementBindingModel managementBindingModel);
        PersonnelUser CreatePersonnelUser(PersonnelUser personnelUser);
    }
}