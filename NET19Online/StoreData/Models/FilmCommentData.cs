using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class FilmCommentData : BaseModel
    {
        public DateTime Created { get; set; }
        public string Comment { get; set; }
        public int FilmId { get; set; }
        public string? UserName { get; set; }   
        public virtual FilmData Film { get; set; }
    }
}
