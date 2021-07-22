using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkyPayment.Core.Entities;
using SkyPayment.Infrastructure.Extensions;

namespace SkyPayment.Infrastructure.Services
{
    public interface IMenuService:IScopedService
    {
        IEnumerable<Menu> GetAllMenus();
    }
}