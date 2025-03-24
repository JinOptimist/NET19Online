using Microsoft.AspNetCore.SignalR;

namespace WebStoryFroEveryting.Hubs
{
    public class PlayerHub : Hub<IPlayerHub>
    {
    }

    public interface IPlayerHub
    {
        Task LikeUpdated(int playerId, int likeCount);
    }
}
