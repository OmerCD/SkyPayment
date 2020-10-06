using Microsoft.AspNetCore.Mvc;
using SkyPayment.Contract.RequestModel;
using SkyPayment.Core.Entities;
using SkyPayment.Repository.Interfaces;

namespace SkyPayment.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        public MenuController()
        {
        }
        
        [HttpPost]
        public IActionResult CreateMenu(CreateMenuRequestModel model)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllMenus()
        {
            return Ok();
        }
    }
}