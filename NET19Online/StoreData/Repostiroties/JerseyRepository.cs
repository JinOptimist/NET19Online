using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class JerseyRepository
    {
        private static List<JerseyData> JerseysDB = new List<JerseyData>();
        public List<JerseyData> GetData()
        {
            return JerseysDB;
        }
        public void AddJersey(JerseyData jerseyData)
        {
            jerseyData.Id = JerseysDB.Count == 0
                ? 1
                : JerseysDB.Max(j => j.Id) + 1;
            JerseysDB.Add(jerseyData);
        }
        public void RemoveJersey(int id)
        {
            JerseyData jerseyData = JerseysDB.Where(j => j.Id == id).FirstOrDefault();
            if (jerseyData != null)
            {
                JerseysDB.Remove(jerseyData);
            }
        }
    }
}
