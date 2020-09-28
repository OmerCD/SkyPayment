using System;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Contract.RequestModel;

namespace SkyPayment.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        [Route("Create")]
        public IActionResult CreateMenu(CreateMenuRequestModel model)
        {
            return Ok();
        }
    }
}