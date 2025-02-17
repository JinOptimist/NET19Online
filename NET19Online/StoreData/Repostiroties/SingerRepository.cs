using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StoreData.Repostiroties
{
    public class SingerRepository
    {
        private static List<SingerData> FakeDB = new();

        public List<SingerData> GetSingers()
        {
            return FakeDB;
        }
        public void AddSinger(SingerData singer)
        {
            if (FakeDB.Count > 0)
            {
                singer.Id = FakeDB.Count + 1;
                FakeDB.Add(singer);
            }
            else
            {
                {
                    singer.Id = 1;
                    FakeDB.Add(singer);
                }
            }
        }
        public void RemoveSinger(int id)
        {
            var singer = FakeDB.Where(s=>s.Id == id).FirstOrDefault();
            if (singer != null)
            {
                FakeDB.Remove(singer);
            }
        }
    }
}
