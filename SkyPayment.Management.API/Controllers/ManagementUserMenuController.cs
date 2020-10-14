using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Contract.RequestModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkyPayment.API.Controllers
{
    [Route("api/[controller]")]
    public class ManagementUserMenuController : Controller
    {
        public IActionResult CreateMenu([FromBody] ManagementUserMenuRequestModel createManagementUserMenu)
        {
            return Ok();
        }
       
    }
}
