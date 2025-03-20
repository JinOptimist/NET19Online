using Microsoft.EntityFrameworkCore;
using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class PlayerRepository : BaseRepository<PlayerData>
    {
        public PlayerRepository(StoreDbContext dbContext) : base(dbContext) { }

        public PlayerData GetWithDescriptionsAndTags(int playerId)
        {
            return _dbSet
                .Include(pd => pd.Descriptions)
                .Include(pd => pd.Tags)
                .First(pd => pd.Id == playerId);
        }

        public void AddTag(int playerId, string tagText)
        {
            var tag = _dbContext.PlayerTags.FirstOrDefault(t => t.Tag == tagText);

            if (tag is null)
            {
                tag = new PlayerTagData { Tag = tagText };
            }

            var player = Get(playerId);
            player.Tags.Add(tag);
            _dbContext.SaveChanges();
        }

        public List<PlayerData> GetAllWithTags(string? tag)
        {
            return _dbSet
                .Include(pd => pd.Tags)
                .Where(pd => tag == null || pd.Tags.Any(t => t.Tag == tag))
                .ToList();
        }

        public void UpdateName(int id, string newName)
        {
            var player = _dbSet.First(x => x.Id == id);
            player.Name = newName;
            _dbContext.SaveChanges();
        }
    }
}
