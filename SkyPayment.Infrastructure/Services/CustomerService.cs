using System;
using System.Linq.Expressions;
using SkyPayment.Core.Entities;
using SkyPayment.Infrastructure.Interface;
using SkyPayment.Repository.Interfaces;

namespace SkyPayment.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly ISecurePasswordHasherService _securePasswordHasherService;

        public CustomerService(IRepository<Customer> customerRepository, ISecurePasswordHasherService securePasswordHasherService)
        {
            _customerRepository = customerRepository;
            _securePasswordHasherService = securePasswordHasherService;
        }

        public Customer CreateCustomer(Customer customer)
        {
            return _customerRepository.InsertOne(customer);
        }

        public Customer GetCustomer(Expression<Func<Customer, bool>> whereClause)
        {
            return _customerRepository.FindOne(whereClause);
        }

        public bool CheckLoginInfo(string userName, string password)
        {
            var user = _customerRepository.FindOne(x => x.NormalizedUserName == userName.Trim().ToLower());
            return user != null && _securePasswordHasherService.Verify(password, user.Password);
        }
    }
}