using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class SingerCommentData
    {
        public int Id { get; set; } 
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public int SingerDataId { get; set; } 
        public virtual SingerData Singer { get; set; }
        public int AuthotId { get; set; }
        public virtual UserData? Author { get; set; }
    }
}
