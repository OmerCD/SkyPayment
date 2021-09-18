using SkyPayment.Core.Entities;
using SkyPayment.Infrastructure.Extensions;

namespace SkyPayment.Infrastructure.Services
{
    public interface IUserService:IScopedService
    {
        bool UserCreate(User user);
    }
}