using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SkyPayment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RoleTestController : ControllerBase
    {
        [HttpGet("manager")]
        [Authorize(Roles = "manager")]
        public IActionResult ManagerTest()
        {
            return Ok();
        }
        [HttpGet("personnel")]
        [Authorize(Roles = "personnel,manager")]
        public IActionResult PersonnelTest()
        {
            return Ok();
        }
        [HttpGet("user")]
        [Authorize(Roles = "user")]
        public IActionResult UserTest()
        {
            return Ok();
        }
    }
}