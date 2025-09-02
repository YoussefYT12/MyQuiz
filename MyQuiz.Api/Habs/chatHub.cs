using Microsoft.AspNetCore.SignalR;


using Microsoft.AspNetCore.SignalR;

namespace MyQuiz.Api.Hab
{
    public class chatHub:Hub
    {
        public void sendMsg(string x)
        {
            Clients.All.SendAsync("display", x);
        }
    }
}
