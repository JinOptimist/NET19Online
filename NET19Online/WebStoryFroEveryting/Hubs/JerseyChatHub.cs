using Microsoft.AspNetCore.SignalR;
using WebStoryFroEveryting.Controllers.CustomAutorizeAttributes;


namespace WebStoryFroEveryting.Hubs
{
    public class JerseyChatHub : Hub<IJerseyChatHub>
    {
        private static string _adminId = null;
        public void SendMessageToClient(string id, string message)
        {
            Clients.Client(id).SendMessage(message);
        }
        public void SendMessageToAdmin(string message)
        {
            if (_adminId is not null)
            {
                Clients.Client(_adminId).SendMessageWithId(Context.ConnectionId, message);
            }
        }

        [IsAdmin]
        public void AdminEnterToChat()
        {
            _adminId = Context.ConnectionId;
            Clients.AllExcept(_adminId).SendMessage("Админ на связи");
        }

        public void ClientEnterToChat()
        {
            if (_adminId is not null)
            {
                Clients.Client(_adminId).SendToAdminThatThereIsNewClientInChat(Context.ConnectionId);
                
                
            }
        }
        
    }
    public interface IJerseyChatHub
    {
        Task SendMessage(string message);
        Task SendMessageWithId(string id, string message);
        Task SendToAdminThatThereIsNewClientInChat(string id);



    }
}
