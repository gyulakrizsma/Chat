using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Web.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessageAsync(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
