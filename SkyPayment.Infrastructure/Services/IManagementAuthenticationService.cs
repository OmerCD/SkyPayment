using SkyPayment.Core.Entities;

namespace SkyPayment.Infrastructure.Services
{
    public interface IManagementAuthenticationService
    {
        public ManagementUser GetManagementUser(string userName);

    }
}