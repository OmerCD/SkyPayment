using Microsoft.AspNetCore.Mvc;

namespace SkyPayment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinkController:ControllerBase
    {
        [HttpGet("{restaurantId}/{tableId}")]
        public IActionResult GetLink(string restaurantId,string tableId)
        {
            return Ok($"http://192.168.31.220:3000/restaurant/{restaurantId}/{tableId}/menu/");
        }
    }
}