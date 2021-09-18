using MongoORM4NetCore.Interfaces;
using SkyPayment.Core.Entities;

namespace SkyPayment.Infrastructure.Services
{
    public class UserService :IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool UserCreate(User user)
        {
            return _userRepository.Insert(user);
        }
    }
}