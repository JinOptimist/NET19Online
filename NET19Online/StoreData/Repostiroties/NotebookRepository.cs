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
         public NotebookData GetWithComments(int notebookId)
        {
            return _dbSet
                .Include(x => x.Comments)
                .First(x => x.Id == notebookId);
        }
    }
}
