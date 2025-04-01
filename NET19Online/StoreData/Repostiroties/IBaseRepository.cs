using StoreData.Models;

namespace StoreData.Repostiroties
{
    public interface IBaseRepository<DbModel> where DbModel : BaseModel
    {
        void Add(DbModel item);
        bool Any();
        DbModel Get(int id);
        List<DbModel> GetAll();
        void Remove(IEnumerable<int> ids);
        void Remove(int id);
    }
}