using System;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Contract.RequestModel;
using SkyPayment.Contract.ResponseModel;

namespace SkyPayment.API.Controllers
{
    
    
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        [Route("Create")]
        public IActionResult CreateMenu(CreateMenuRequestModel model)
        {
            /* Tabii ki servise alınacak. Sakin olunuz. */ 
            var deneme = new CreateMenuResponseModel()
            {
                Name = model.Name,
                Type = model.Type,
                CreateDateTime =DateTime.Now
            };

            return Ok();
        }
    }
}