using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SkyPayment.Personnel.API.Hub
{
    public class PersonnelHub:Microsoft.AspNetCore.SignalR.Hub
    {
        public static HashSet<string> ActiveUsers = new HashSet<string>();

        public override Task OnConnectedAsync()
        {
            ActiveUsers.Add(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public async Task Deneme(string metin)
        {
            /* bir test metodu. Giden veri görünüyor mu? */
            await Clients.All.SendAsync("DenemeMesajı", metin);
        }
    }
}