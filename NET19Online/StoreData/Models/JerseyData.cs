using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class JerseyData : BaseModel
    {
        public string Club { get; set; }
        public int Number { get; set; }
        public string AthleteName { get; set; }
        public string Img { get; set; }
        public string? SecondImg { get; set; }
        public int InStock { get; set; }
        public decimal Price { get; set; }
        public virtual List<JerseyCommentData> Comments { get; set; }
        public virtual List<JerseyTagData> Tags { get; set; } = new List<JerseyTagData>();
    }
}
