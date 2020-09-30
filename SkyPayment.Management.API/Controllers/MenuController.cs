using Microsoft.AspNetCore.Mvc;
using SkyPayment.Contract.RequestModel;
using SkyPayment.Core.Entities;
using SkyPayment.Infrastructure.Interface;
using SkyPayment.Repository.Interfaces;

namespace SkyPayment.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        
        [HttpPost]
        public IActionResult CreateMenu(CreateMenuRequestModel model)
        {
            _menuService.Add(model);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllMenus()
        {
            return Ok(_menuService.GetAll());
        }
    }
}