using Microsoft.AspNetCore.SignalR;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEveryting.Hubs
{
    public class HunterHub : Hub<IHunterHub>
    {

    }
    public interface IHunterHub
    {
        Task Like(int id, int likesCount);
        Task Dislike(int id, int dislikesCount);
    }
}
