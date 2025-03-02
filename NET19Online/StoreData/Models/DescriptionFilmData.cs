using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class DescriptionFilmData : BaseModel
    {
        public string DescriptionFilm { get; set; }
        public DateTime? Created { get; set; }
        public virtual FilmData Films { get; set; }
    }
}
