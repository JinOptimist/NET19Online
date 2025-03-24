using Microsoft.EntityFrameworkCore;
using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class JerseyRepository : BaseRepository<JerseyData>
    {
        public JerseyRepository(StoreDbContext dbContext) : base(dbContext) { }

        public void AddTag(int jerseyId, string tagString)
        {
            var tag = _dbContext.JerseysTags.FirstOrDefault(tag => tag.Tag == tagString);

            if (tag is null)
            {
                tag = new JerseyTagData { Tag = tagString };
            }
            var jersey = Get(jerseyId);
            jersey.Tags.Add(tag);
            _dbContext.SaveChanges();
        }

        public JerseyData GetWithCommentsAndTags(int jerseyId)
        {
            return _dbSet
                .Include(x => x.Comments)
                .ThenInclude(comment => comment.Author)
                .Include(x => x.Tags)
                .First(x => x.Id == jerseyId);
        }

        public List<JerseyData> GetAllWithTags(string? tag)
        {
            return _dbSet
                .Include(x => x.Tags)
                .Where(x => tag == null || x.Tags.Any(t => t.Tag == tag))
                .ToList();
        }
        public int AddJerseyAndGetId(JerseyData jerseyData)
        {
            Add(jerseyData);
            return _dbSet.OrderByDescending(x => x.Id).First().Id;
        }
        
    }
}
