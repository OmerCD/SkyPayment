using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SkyPayment.Personnel.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonnelController : ControllerBase
    {
      
        /* Business eklenecektir. */ 
        public PersonnelController()
        {
            
        }

        public IActionResult Orders()
        {
            return Ok();
        }
    }
}