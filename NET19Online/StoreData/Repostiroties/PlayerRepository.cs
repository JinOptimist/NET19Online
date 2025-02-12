using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class PlayerRepository
    {
        private static List<PlayerData> FakeDB = new();

        public List<PlayerData> GetPlayers()
        {
            return FakeDB;
        }

        public void AddPlayer(PlayerData player)
        {
            player.Id = FakeDB.Any()
                ? FakeDB.Max(p => p.Id) + 1
                : 1;
            FakeDB.Add(player);
        }

        public void RemovePlayer(int id)
        {
            var index = FakeDB.FindIndex(p => p.Id == id);
            if (index != -1)
            {
                FakeDB.RemoveAt(index);
            }
        }
    }
}
