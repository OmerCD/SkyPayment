using SkyPayment.Core.Entities;

namespace SkyPayment.Infrastructure.Interface
{
    public interface ICustomerService : IService
    {
        Customer CreateCustomer(Customer customer);
    }
}