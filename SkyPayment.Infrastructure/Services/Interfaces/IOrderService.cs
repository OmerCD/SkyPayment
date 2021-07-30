using System.Threading.Tasks;
using SkyPayment.Core.Entities;
using SkyPayment.Infrastructure.Extensions;

namespace SkyPayment.Infrastructure.Services
{
    public interface IOrderService:IScopedService
    {
        bool CreateOrder(Order order);
    }
}