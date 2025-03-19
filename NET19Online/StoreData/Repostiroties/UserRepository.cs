using Enums.User;
using Microsoft.EntityFrameworkCore;
using StoreData.CustomQueryModels;
using StoreData.Models;
using System.Xml.Serialization;

namespace StoreData.Repostiroties
{
    public class UserRepository : BaseRepository<UserData>
    {
        public UserRepository(StoreDbContext dbContext) : base(dbContext) { }

        public override void Add(UserData item)
        {
            throw new Exception("DO NOT use Add for creating user. We have method Registration for it");
        }

        public bool Any(string name)
        {
            return _dbSet.Any(x => x.UserName == name);
        }

        public List<UserData> GetAllWithRole()
        {
            return _dbSet
                .Include(x => x.Role)
                .ToList();
        }

        public UserData? Login(string userName, string password)
        {
            var securePassword = BuildSecurePassword(password);
            return _dbSet
                .Include(x => x.Role)
                .FirstOrDefault(x => x.UserName == userName && x.Password == securePassword);
        }

        public void Registration(string userName, string password)
        {
            var userData = new UserData
            {
                UserName = userName,
                Password = BuildSecurePassword(password),
            };

            _dbSet.Add(userData);
            _dbContext.SaveChanges();
        }

        public void UpdateRole(int id, int? roleId)
        {
            var user = _dbSet
                .Include(x => x.Role)
                .First(x => x.Id == id);
            var role = roleId == null
                ? null
                : _dbContext.Roles.First(x => x.Id == roleId);
            user.Role = role;
            _dbContext.SaveChanges();
        }

        public List<UserWithIdolPreference> GetUserNamesWithAveIdolAge()
        {
            var sql = @"SELECT
	U.[UserName]
	, AVG(I.Age) AvgAge
FROM [Users] U
	LEFT JOIN IdolComments C ON U.Id = C.AuthorId
	LEFT JOIN Idols I ON I.Id = C.IdolId
GROUP BY U.UserName";

            return _dbContext
                .Database
                .SqlQueryRaw<UserWithIdolPreference>(sql)
                .ToList();
        }

        private string BuildSecurePassword(string password)
        {
            return password
                .Replace('a', '!')
                .Replace('e', '!');
        }

        public UserLocale GetLocale(int userId)
        {
            return _dbSet
                .First(x => x.Id == userId)
                .Local;
        }

        public void UpdateLocal(int id, UserLocale newLocal)
        {
            var user = _dbSet.First(x => x.Id == id);
            user.Local = newLocal;
            _dbContext.SaveChanges();
        }
    }
}
