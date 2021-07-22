using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Domain.Queries.MenuQueries;

namespace SkyPayment.API.Controllers
{
    public class MenuController:ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult GetMenus()
        {
            var getAllMenuQueries = new GetAllMenuQueries();
            var send = _mediator.Send(getAllMenuQueries);
            return Ok(send);
        }
    }
}