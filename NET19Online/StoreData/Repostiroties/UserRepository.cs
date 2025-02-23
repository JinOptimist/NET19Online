using StoreData.Models;

namespace StoreData.Repostiroties
{
    public class UserRepository : BaseRepository<UserData>
    {
        public UserRepository(StoreDbContext dbContext) : base(dbContext) { }

        public override void Add(UserData item)
        {
            throw new Exception("DO NOT use Add for creating user. We have method Registration for it");
        }

        public UserData Login(string userName, string password)
        {
            var securePassword = BuildSecurePassword(password);
            return _dbSet
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

        private string BuildSecurePassword(string password)
        {
            return password
                .Replace('a', '!')
                .Replace('e', '!');
        }
    }
}
