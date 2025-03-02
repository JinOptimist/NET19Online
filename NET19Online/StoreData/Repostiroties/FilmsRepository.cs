﻿using Microsoft.EntityFrameworkCore;
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

        public FilmData GetFilm(int id)
        {
            var film = _dbSet
                 .Include(x => x.DescriptionFilmData)
                 .Include(x=>x.Comments)
                 .First(x => x.Id == id);
            return film;
        }

        public FilmData GetFilmComment(int filmid)
        {
            var film = _dbSet.Include(x => x.Comments)
                .Include(x=>x.DescriptionFilmData)
                .First(x => x.Id == filmid);
            return film;
        }
    }
}
