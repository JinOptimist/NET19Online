using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class UnderwarterHunterRepository
    {
        private static List<UnderwaterHunterData> ExampleBD = new();

        public List<UnderwaterHunterData> GetHunters() 
        { 
            return ExampleBD; 
        }
        public void AddHunters(UnderwaterHunterData hunter)
        {
            hunter.Id = ExampleBD.Count > 0
                ? ExampleBD.Max(x => x.Id) + 1
                : 1;
            ExampleBD.Add(hunter);
        }
        public void Remove(int id)
        {
            ExampleBD=ExampleBD.Where(x=>x.Id!=id).ToList();
        }
    }
}
