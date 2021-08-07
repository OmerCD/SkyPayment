using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using MongoORM4NetCore.Interfaces;
using SkyPayment.Core.Entities;
using SkyPayment.Infrastructure.Hubs;

namespace SkyPayment.Infrastructure.Services
{
    public class OrderService:IOrderService
    {
       private readonly IHubContext<OrderHub> _orderHub;
       private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
         //   _orderHub = orderHub;
        }

        public bool CreateOrder(Order order)
        {
           _orderHub.Clients.All.SendAsync("OrderCreate",order);
           return  _orderRepository.Insert(order);   
           return true;
        }
    }
}