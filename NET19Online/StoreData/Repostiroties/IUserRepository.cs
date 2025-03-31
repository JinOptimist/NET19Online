using Enums.User;
using StoreData.CustomQueryModels;
using StoreData.Models;

namespace StoreData.Repostiroties
{
    public interface IUserRepository : IBaseRepository<UserData>
    {
        bool Any(string name);
        List<UserData> GetAllWithRole();
        UserLocale GetLocale(int userId);
        List<UserWithIdolPreference> GetUserNamesWithAveIdolAge();
        UserData? Login(string userName, string password);
        void Registration(string userName, string password);
        void UpdateLocal(int id, UserLocale newLocal);
        void UpdateRole(int id, int? roleId);
    }
}