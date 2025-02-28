using System.Security.Cryptography;
using System.Text;
using Enums.SchoolUser;
using Microsoft.EntityFrameworkCore;
using StoreData.Models;

namespace StoreData.Repostiroties;

public class SchoolUserRepository : BaseSchoolRepository<SchoolUserData>
{
    private readonly SchoolRoleRepository _schoolRoleRepository;
    public SchoolUserRepository(SchoolDbContext dbContext, SchoolRoleRepository schoolRoleRepository) : base(dbContext)
    {
        _schoolRoleRepository = schoolRoleRepository;
    }

    public override void Add(SchoolUserData item)
    {
        throw new Exception("DO NOT use Add for creating user. We have method Registration for it");
    }

    public List<SchoolUserData> GetAllWithRole()
    {
        return _dbSet
            .Include(u => u.Role)
            .ToList();
    }

    public void Registration(string username, string email, string password)
    {
        var user = new SchoolUserData()
        {
            Username = username,
            Email = email,
            Password = HashPassword(password),
            Role = _schoolRoleRepository.GetRoleByName("User")
        };
        _dbSet.Add(user);
        _dbContext.SaveChanges();
    }

    public SchoolUserData Login(string username, string password)
    {
        var hashPassword = HashPassword(password);
        return _dbSet
            .Include(x => x.Role)
            .First(u => u.Username == username && u.Password == hashPassword);
    }
    
    public string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var inputBytes = Encoding.UTF8.GetBytes(password);
        var hashBytes = sha256.ComputeHash(inputBytes);
        return Convert.ToHexString(hashBytes);
    }
}