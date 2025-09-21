using Microsoft.AspNetCore.SignalR;

namespace Server
{
    public class LogHub : Hub
    {
        public async Task StartStreaming()
        {
            for (int i = 0; i < 5; i++)
            {
                var log = $"Log entry {i} at {DateTime.Now:T}";
                await Clients.Caller.SendAsync("ReceiveLog", log);
                await Task.Delay(1000);
            }
        }
    }
}


