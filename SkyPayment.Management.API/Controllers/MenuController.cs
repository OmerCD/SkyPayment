using System;
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

        [Route("Create")]
        public IActionResult CreateMenu(CreateMenuRequestModel model)
        {
            return Ok();
        }
    }
}