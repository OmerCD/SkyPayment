using SkyPayment.Core.Entities;

namespace SkyPayment.Infrastructure.Services
{
    public interface IUserService
    {
        bool UserCreate(User user);
    }
}