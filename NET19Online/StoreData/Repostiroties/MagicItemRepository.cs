using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class MagicItemRepository
    {
        private static List<MagicItemData> FakeDB = new();

        public List<MagicItemData> GetMagicItems()
        {
            return FakeDB;
        }

        public void AddMagicItem(MagicItemData item)
        {
            item.Id = FakeDB.Count > 0
                ? FakeDB.Max(x => x.Id) + 1
                : 1;
            FakeDB.Add(item);
        }

        public void Remove(int id)
        {
            FakeDB = FakeDB.Where(x => x.Id != id).ToList();
        }
    }
}
