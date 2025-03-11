using Microsoft.EntityFrameworkCore;
using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class PlayerDescriptionRepository : BaseRepository<PlayerDescriptionData>
    {
        public PlayerDescriptionRepository(StoreDbContext dbContext) : base(dbContext) { }

        public void AddDescription(int playerId, string description)
        {
            var player = _dbContext.FootballPlayers.First(fp => fp.Id == playerId);
            var playerDescription = new PlayerDescriptionData()
            {
                Description = description,
                Player = player
            };

            Add(playerDescription);
        }

        public void DeleteDescriptionDuplicates()
        {
            var sql = @"DELETE PlayerDescriptions FROM PlayerDescriptions
                        LEFT JOIN (
                        SELECT MAX(id) as lastId FROM PlayerDescriptions GROUP BY Description, AuthorId
                        ) 
                        AS filtered ON PlayerDescriptions.id = filtered.lastId
                        WHERE filtered.lastId IS NULL;";

            _dbContext.Database.ExecuteSqlRaw(sql);
        }
    }
}
