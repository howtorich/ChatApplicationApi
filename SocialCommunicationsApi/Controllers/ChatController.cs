namespace SocialCommunicationsApi.Controllers
{
    using Microsoft.AspNet.SignalR.Hubs;
    using Microsoft.AspNetCore.SignalR;

    [HubName("chatHub")]
    public class ChatController : Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.Client(Context.ConnectionId).SendAsync("Receive", name, message).Wait();

            //Clients.User("").SendAsync("", "");
        }
    }
}