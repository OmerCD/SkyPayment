using System;
using System.Linq.Expressions;
using SkyPayment.Core.Entities;

namespace SkyPayment.Infrastructure.Interface
{
    public interface ICustomerService : IService
    {
        Customer CreateCustomer(Customer customer);
        bool CheckLoginInfo(string userName, string password);
        Customer GetCustomer(Expression<Func<Customer, bool>> whereClause);
    }
}