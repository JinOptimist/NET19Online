using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
        
        public class NotebookCommentData : BaseModel
        {
            public DateTime Created { get; set; }   
            public string Comment { get; set; }

            public virtual NotebookData Notebook { get; set; }

            public virtual UserData? Author { get; set; }

        }
    
}
