using Microsoft.EntityFrameworkCore;
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

        public FilmData GetDescription(int id)
        {
            var film = _dbSet
                 .Include(x => x.DescriptionFilmData).First(x => x.Id == id);
            return film;
        }
    }
}
