using System;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Contract.RequestModel;

namespace SkyPayment.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        [Route("auth")]
        public IActionResult Login (LoginModel model)
        {
            /* Sadece test. Lütfen dalga geçmeyin.*/
            if (model.UserName=="user")
            {
                if (model.Password=="123")
                {
                    return Ok();
                }
            }

            return BadRequest();
        }
    }
}