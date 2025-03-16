using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class SingerData
    {
     public int Id { get; set; }
     public string Pseudonym { get; set; }
     public string Src { get; set; }
     public string Style { get; set; }
     public List<SingerCommentData> Comments { get; set; }
    }
}
