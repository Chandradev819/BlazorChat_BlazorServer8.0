using Microsoft.AspNetCore.SignalR;

namespace BlazorChat.BlazorChat
{
    public class ChatHub : Hub
    {
        // This method will be used to send messages to clients
        public async Task SendMessage(string user, string message)
        {
            // Broadcast the message to all connected clients
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
