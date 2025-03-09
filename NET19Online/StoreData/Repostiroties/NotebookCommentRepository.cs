using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class NotebookCommentRepository : BaseRepository<NotebookCommentData>
    {       
        public NotebookCommentRepository(StoreDbContext dbContext):base(dbContext) { }

        public void AddComment(int notebookId, string comment)
        {
            var notebook = _dbContext.Notebooks.First(x => x.Id == notebookId);
            var notebookComment = new NotebookCommentData
            {
                Created = DateTime.Now,
                Comment = comment,
                Notebook = notebook
            };

            Add(notebookComment);
        }
    }
}
