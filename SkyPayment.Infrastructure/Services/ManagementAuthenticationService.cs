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
            var normalizedUserName = userName.ToUpper().Trim();
            return _managementUserRepository.FindOne(x => x.NormalizedUserName == normalizedUserName);
        }

        public ManagementUser CreateManagementUser(ManagementBindingModel managementBindingModel)
        {
           return _managementUserRepository.InsertOne(Build(managementBindingModel));
        }

        private ManagementUser Build(ManagementBindingModel managementBindingModel)
        {
            return new ManagementUser
            {
                Email = managementBindingModel.Email.Trim(),
                Name = managementBindingModel.Name.Trim(),
                Password = managementBindingModel.Password.Trim(),
                LastName = managementBindingModel.LastName.Trim(),
                UserName = managementBindingModel.UserName.Trim(),
                NormalizedUserName = managementBindingModel.UserName.Trim().ToUpper()
            };
        }
    }
}