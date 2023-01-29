using Microsoft.AspNetCore.SignalR;

namespace WebAppGame.Hubs
{
    public class GameHub : Hub
    {       
        public async Task SendJson(string from, string to, string message)
        {
            await Clients.All.SendAsync("ReceiveJson", from, to, message);
        }
        public async Task Restart(string from, string to)
        {
            await Clients.All.SendAsync("RestartEvent", from, to);
        }
        //public async Task 
    }
}
