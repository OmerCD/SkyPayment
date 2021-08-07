using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using MediatR;
using SkyPayment.Core.Entities;
using SkyPayment.Domain.Commands.OrderCommand;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.Domain.Handler.OrderHandler
{
    public class OrderCreateHandler:IRequestHandler<OrderCreateCommand,bool>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        
        public OrderCreateHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        
        public Task<bool> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            return Task.FromResult(_orderService.CreateOrder(order));
        }
     
    }
}