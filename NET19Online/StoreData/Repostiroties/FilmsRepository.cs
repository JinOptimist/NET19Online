using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class FilmsRepository
    {
        private static List<FilmsDate> FilmsDatesBase = new ();
        public void AddFilm (FilmsDate filmsDate)
        {
            FilmsDatesBase.Add(filmsDate);
        }
        public void RemoveFilm()
        { 
        
        }
    }
}
