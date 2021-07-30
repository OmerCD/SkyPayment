using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SkyPayment.Infrastructure.Hubs
{
    public class OrderHub:Hub
    {
        public override Task OnConnectedAsync()
        {
          return  Clients.All.SendAsync("SendOrder");
        }
    }
}