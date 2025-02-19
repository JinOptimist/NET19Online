using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class FilmsRepository : BaseFilmsRepository<FilmData>
    {
         public FilmsRepository(StoreDbContext filmsDbContext) : base(filmsDbContext) { }
    }
}
