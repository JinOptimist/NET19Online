using Enums.User;
using StoreData.Models;

namespace StoreData.Repostiroties
{
    public class RoleRepository : BaseRepository<RoleData>
    {
        public RoleRepository(StoreDbContext storeDbContext) : base(storeDbContext) { }

        public void UpdatePermission(int id, List<Permisson> permissons)
        {
            var role = _dbSet.First(x => x.Id == id);
            role.Permisson = permissons.Aggregate((summ, val) => summ | val);
            _dbContext.SaveChanges();
        }
    }
}
