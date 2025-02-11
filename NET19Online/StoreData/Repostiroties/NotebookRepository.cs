using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class NotebookRepository
    {
        private static List<NotebookData> FakeDB = new();

        public List<NotebookData> GetNotebooks() 
        {
            return FakeDB; 
        }

        public void AddNotebook(NotebookData notebook)
        {
            notebook.Id = FakeDB.Count > 0 ? FakeDB.Max(x => x.Id) + 1:  1;
            FakeDB.Add(notebook);
        }

        public void Remove(int id) 
        {
            FakeDB = FakeDB.Where(x => x.Id != id).ToList();
        }

    }
}
