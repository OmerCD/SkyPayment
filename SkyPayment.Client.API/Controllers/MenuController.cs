using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Domain.CQ.Queries.MenuQueries;

namespace SkyPayment.Client.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController
    {
        [HttpGet("{managementUserId}/{restaurantId}")]
        public async Task<IActionResult> GetMenus(string managementUserId, string restaurantId)
        {
            var query = new GetRestaurantMenuQuery(managementUserId, restaurantId);
            throw new NotImplementedException();
        }
    }
}