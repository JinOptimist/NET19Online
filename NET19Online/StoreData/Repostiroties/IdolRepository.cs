using StoreData.Models;

namespace StoreData.Repostiroties
{
    public class IdolRepository
    {
        private static List<IdolData> FakeDB = new();

        public List<IdolData> GetIdols()
        {
            return FakeDB;
        }

        public void AddIdol(IdolData idol)
        {
            idol.Id = FakeDB.Count > 0
                ? FakeDB.Max(x => x.Id) + 1
                : 1;
            FakeDB.Add(idol);
        }

        public void Remove(int id)
        {
            FakeDB = FakeDB.Where(x => x.Id != id).ToList();
        }
    }
}
