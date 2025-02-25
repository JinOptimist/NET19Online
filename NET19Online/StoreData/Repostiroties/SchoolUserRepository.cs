using System.Security.Cryptography;
using System.Text;
using StoreData.Models;

namespace StoreData.Repostiroties;

public class SchoolUserRepository : BaseSchoolRepository<SchoolUserData>
{
    public SchoolUserRepository(SchoolDbContext dbContext) : base(dbContext) { }

    public override void Add(SchoolUserData item)
    {
        throw new Exception("DO NOT use Add for creating user. We have method Registration for it");
    }

    public void Registration(string username, string email, string password)
    {
        var user = new SchoolUserData()
        {
            Username = username,
            Email = email,
            Password = HashPassword(password)
        };
        _dbSet.Add(user);
        _dbContext.SaveChanges();
    }

    public SchoolUserData Login(string username, string password)
    {
        var hashPassword = HashPassword(password);
        return _dbSet.First(u => u.Username == username && u.Password == hashPassword);
    }
    
    public string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        byte[] inputBytes = Encoding.UTF8.GetBytes(password);
        byte[] hashBytes = sha256.ComputeHash(inputBytes);
        return Convert.ToHexString(hashBytes);
    }
}