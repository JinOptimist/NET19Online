using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class FilmsRepository : BaseRepository<FilmData>
    {
        public FilmsRepository(StoreDbContext filmsDbContext) : base(filmsDbContext) { }
        private static List<FilmData> FilmsDatesBase = new();

        public List<FilmData> GetItems()
        {
            return FilmsDatesBase;
        }
        public void AddFilml(FilmData films)
        {
            films.Id = FilmsDatesBase.Count > 0
                ? FilmsDatesBase.Max(x => x.Id) + 1
                : 1;
            FilmsDatesBase.Add(films);
        }

        public void RemoveFilm(int id)
        {
            var result = FilmsDatesBase.FirstOrDefault(x => x.Id == id);
            FilmsDatesBase.Remove(result);
        }
    }
}
