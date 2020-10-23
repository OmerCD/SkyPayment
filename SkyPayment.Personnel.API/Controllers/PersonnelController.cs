using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SkyPayment.Personnel.API.Hub;

namespace SkyPayment.Personnel.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonnelController : ControllerBase
    {
        private readonly IHubContext<PersonnelHub> _hubContext;
        /* Business eklenecektir. */ 
        public PersonnelController(IHubContext<PersonnelHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public IActionResult Orders()
        {
            return Ok();
        }
    }
}