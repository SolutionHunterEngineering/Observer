using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Server
{
    public class ObserverHub : Hub
    {
        // Simple broadcast method for test
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}