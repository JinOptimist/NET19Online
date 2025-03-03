using StoreData.Models;

namespace StoreData.Repostiroties;

public class SchoolRoleRepository : BaseSchoolRepository<SchoolRoleData>
{
    public SchoolRoleRepository(SchoolDbContext dbContext) : base(dbContext) { }

    public SchoolRoleData GetRoleByName(string roleName)
    {
        return _dbSet.First(r => r.Name == roleName);
    }
}