using System.Collections.Generic;
using System.Threading.Tasks;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Core.Entities;
using SkyPayment.Domain.Commands.OrderCommand;
using SkyPayment.Shared.Order;

namespace SkyPayment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateModel createOrderModel)
        {
            var menuItems = _mapper.Map<ICollection<MenuItem>>(createOrderModel.OrderList);
            var orderCreateCommand = new OrderCreateCommand(createOrderModel.RestaurantId, createOrderModel.TableNumber,
                menuItems, createOrderModel.Price);

            var send = await _mediator.Send(orderCreateCommand);
            return Ok(send);
   
        }
        
    }
}