using Microsoft.EntityFrameworkCore;
using StoreData.Models;



namespace StoreData.Repostiroties
{
    public class TanksRepository
    {

        public static List<TanksData> FakeDB = new();

        public List<TanksData> GetTank()
        {
            return FakeDB;
        }

        public  void AddTank(TanksData tank)
        {
            tank.Id = FakeDB.Count > 0  
                ? FakeDB.Max(x => x.Id) + 1
                :1;

            FakeDB.Add(tank);
        }

        public void Remove(int id)
        {
            FakeDB = FakeDB.Where(x => x.Id != id).ToList();
        }

    }
}
