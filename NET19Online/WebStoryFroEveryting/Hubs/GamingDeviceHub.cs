using Microsoft.AspNetCore.SignalR;
using StoreData.Models;
using WebStoryFroEveryting.Models.GamingDevice;

namespace WebStoryFroEveryting.Hubs
{
    public class GamingDeviceHub : Hub<IGamingDeviceHub>
    {

    }

    public interface IGamingDeviceHub
    {
        Task GamingDeviceWasAdded(GamingDeviceData device);
        Task GamingDeviceWasRemoved(int deviceId);
    }
}
