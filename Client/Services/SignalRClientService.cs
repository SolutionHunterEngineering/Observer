using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Client.Services
{
    public class SignalRClientService
    {
        private HubConnection? _connection;

        public event Action<string>? OnLogReceived;

        public async Task ConnectAsync(string serverUrl)
        {
            _connection = new HubConnectionBuilder()
                .WithUrl($"{serverUrl}")
                .WithAutomaticReconnect()
                .Build();

            _connection.On<string>("ReceiveLogMessage", (message) =>
            {
                OnLogReceived?.Invoke(message); // <<<<<<Add it to the list to be displayed !!!!!!!!
            });

            await _connection.StartAsync();
            await _connection.InvokeAsync("StartLogStreaming");
        }


        public async Task StopAsync()
        {
            if (_connection is not null)
            {
                await _connection.StopAsync();
            }
        }
    }
}
