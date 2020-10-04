using System.Linq;
using SkyPayment.Core.BindingModel;
using SkyPayment.Core.Entities;
using SkyPayment.Repository.Interfaces;

namespace SkyPayment.Infrastructure.Services
{
    public class ManagementAuthenticationService :IManagementAuthenticationService
    {
        private readonly IRepository<ManagementUser> _managementUserRepository;

        public ManagementAuthenticationService(IRepository<ManagementUser> managementUserRepository)
        {
            _managementUserRepository = managementUserRepository;
        }

        public ManagementUser GetManagementUser(string userName)
        {
            return _managementUserRepository.FindOne(x => x.UserName == userName);
        }

        public ManagementUser CreateManagementUser(ManagementBindingModel managementBindingModel)
        {
           return _managementUserRepository.InsertOne(Build(managementBindingModel));
        }

        private ManagementUser Build(ManagementBindingModel managementBindingModel)
        {
            return new ManagementUser
            {
                Email = managementBindingModel.Email,
                Name = managementBindingModel.Name,
                Password = managementBindingModel.Password,
                LastName = managementBindingModel.LastName,
                UserName = managementBindingModel.UserName
            };
        }
    }
}