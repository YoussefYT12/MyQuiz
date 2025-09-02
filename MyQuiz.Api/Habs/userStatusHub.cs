using Microsoft.AspNetCore.SignalR;

namespace MyQuiz.Api.Habs
{
    public class userStatusHub : Hub
    {
        private static int onlineUsers = 0;
        public async override Task OnConnectedAsync()
        {
            onlineUsers++;
            await Clients.All.SendAsync("userCount", onlineUsers);
            await base.OnConnectedAsync();
        }

        public async override Task OnDisconnectedAsync(Exception? exception)
        {
            onlineUsers--;
            await Clients.All.SendAsync("userCount", onlineUsers);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
