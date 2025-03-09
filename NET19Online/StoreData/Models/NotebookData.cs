using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class NotebookData : BaseModel
    {
        public string Name { get; set; }
        public string Src { get; set; }

        public virtual List<NotebookCommentData> Comments { get; set; }
    }
}
