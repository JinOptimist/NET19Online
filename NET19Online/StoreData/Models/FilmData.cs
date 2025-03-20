using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class FilmData : BaseModel
    {
        public DateTime FilmDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Src { get; set; }
        public virtual DescriptionFilmData? DescriptionFilms { get; set; }
        public virtual List<FilmCommentData> Comments { get; set; }
    }
}
