using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SkyPayment.Core.Value;

namespace SkyPayment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinkController:ControllerBase
    {
        private readonly Settings _settings;

        public LinkController(IOptions<Settings> settings)
        {
            _settings = settings.Value;
        }

        [HttpGet("{restaurantId}/{tableId}")]
        public IActionResult GetLink(string restaurantId,string tableId)
        {
            return Ok($"{_settings.BaseQRLink}/restaurant/{restaurantId}/{tableId}/menu/");
        }
    }
}