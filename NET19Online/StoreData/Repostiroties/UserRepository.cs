using Microsoft.EntityFrameworkCore;
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

        private string BuildSecurePassword(string password)
        {
            return password
                .Replace('a', '!')
                .Replace('e', '!');
        }
    }
}
