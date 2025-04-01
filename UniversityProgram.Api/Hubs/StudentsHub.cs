using Microsoft.AspNetCore.SignalR;

namespace UniversityProgram.Api.Hubs
{
    public class StudentsHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
