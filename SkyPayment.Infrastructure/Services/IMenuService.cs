using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkyPayment.Core.Entities;

namespace SkyPayment.Infrastructure.Services
{
    public interface IMenuService
    {
        IEnumerable<Menu> GetAllMenus();
    }
}