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
        private static List<FilmsDate> FilmsDatesBase = new();

        public List<FilmsDate> GetItems()
        {
            return FilmsDatesBase;
        }
        public void AddFilml(FilmsDate films)
        {
            films.IdFilm = FilmsDatesBase.Count > 0
                ? FilmsDatesBase.Max(x => x.IdFilm) + 1
                : 1;
            FilmsDatesBase.Add(films);
        }

        public void RemoveFilm(int id)
        {
            var t = FilmsDatesBase.FirstOrDefault(x => x.IdFilm==id);
            FilmsDatesBase.Remove(t);
        }
    }
}
