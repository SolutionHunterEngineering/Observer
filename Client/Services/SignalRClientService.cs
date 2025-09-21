using Microsoft.AspNetCore.SignalR.Client;

namespace Client.Services
{
    public class SignalRClientService
    {
        private HubConnection _connection;

        public async Task InitializeAsync()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/logHub") // adjust port if needed
                .Build();

            _connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Console.WriteLine($"[{user}]: {message}");
                // Later: update UI or state instead of just Console
            });

            await _connection.StartAsync();
        }

        public async Task SendStartStreamingCommandAsync(string user, string msg)
        {
            if (_connection == null)
                throw new InvalidOperationException("SignalR connection not initialized.");

            await _connection.SendAsync("SendMessage", user, msg);
        }
    }
}