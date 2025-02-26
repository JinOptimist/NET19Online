using StoreData.Models;

namespace StoreData.Repostiroties;

public class SchoolRoleRepository : BaseSchoolRepository<SchoolRoleData>
{
    public SchoolRoleRepository(SchoolDbContext dbContext) : base(dbContext) { }
}