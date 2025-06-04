using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class SingerData : BaseModel
    {
     public string Pseudonym { get; set; }
     public string Src { get; set; }
     public string Style { get; set; }
     public List<SingerCommentData> Comments { get; set; }
    }
}
