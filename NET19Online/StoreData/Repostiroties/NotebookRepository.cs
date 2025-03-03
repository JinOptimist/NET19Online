using Microsoft.EntityFrameworkCore;
using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class NotebookRepository : BaseRepository<NotebookData>
    {       

        public NotebookRepository(StoreDbContext dbContext):base(dbContext) { }

        public void AddNotebooks(List<NotebookData> notebooks)
        {
            _dbContext.Notebooks.AddRange(notebooks);
            _dbContext.SaveChanges();
        }        

        public void AddTag(int notebookId, string tagText)
        {
            var tag = _dbContext.NotebookTags.FirstOrDefault(x => x.Tag == tagText);
            if (tag is null) 
            {
                tag = new NotebookTagData { Tag = tagText };
            }

            var notebook = Get(notebookId);
            notebook.Tags.Add(tag);
            _dbContext.SaveChanges();
        }

        public List<NotebookData> GetAllWithTags(string? tag)
        {
            return _dbSet
                .Include(x => x.Tags)
                .Where(notebook=> tag == null || notebook.Tags.Any(t => t.Tag == tag))
                .ToList();
        }
         public NotebookData GetWithCommentsAndTags(int notebookId)
        {
            return _dbSet
                .Include(x => x.Comments)
                .Include(x => x.Tags)
                .First(x => x.Id == notebookId);
        }
    }
}
