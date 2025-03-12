using Microsoft.AspNetCore.SignalR;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEveryting.Hubs
{
    public class ChatHub : Hub<IChatHub>
    {
        private AuthService _authService;

        public ChatHub(AuthService authService)
        {
            _authService = authService;
        }

        public void AddMessage(string message)
        {
            var userName = _authService.GetUserName();
            Clients
                .All
                .NewMessageArrived(userName, message)
                .Wait();

        }

        public void EnterToChat()
        {
            var userName = _authService.GetUserName();
            Clients
                .All
                .NewUserInChat(userName)
                .Wait();
        }
    }

    public interface IChatHub
    {
        Task NewMessageArrived(string userName, string message);
        Task NewUserInChat(string userName);
    }
}
