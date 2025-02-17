using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class FilmsRepository : BaseFilmsRepository<DateFilm>
    {
        private static List<DateFilm> FilmsDatesBase = new();

        public FilmsRepository(FilmsDbContext filmsDbContext): base(filmsDbContext) { }



        //public List<DateFilm> GetItems()
        //{
        //    return FilmsDatesBase;
        //}
        //public void AddFilml(DateFilm films)
        //{
        //    films.IdFilm = FilmsDatesBase.Count > 0
        //        ? FilmsDatesBase.Max(x => x.IdFilm) + 1
        //        : 1;
        //    FilmsDatesBase.Add(films);
        //}

        //public void RemoveFilm(int id)
        //{
        //    var t = FilmsDatesBase.FirstOrDefault(x => x.IdFilm==id);
        //    FilmsDatesBase.Remove(t);
        //}
    }
}
