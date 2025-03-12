using Microsoft.AspNetCore.SignalR;

namespace WebStoryFroEveryting.Hubs
{
    public class IdolHub : Hub<IIdolHub>
    {
    }

    public interface IIdolHub
    {
        Task LikeUpdated(int idolId, int likeCount);
    }
}
