﻿using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Repostiroties
{
    public class FilmCommentRepository : BaseRepository<FilmCommentData>
    {
        public FilmCommentRepository(StoreDbContext dbContext) : base(dbContext) { }

        public void AddComment(int filmid, string comment)
        {
            var filmComment = new FilmCommentData();
            filmComment.FilmId = filmid;
            filmComment.Comment = comment;
            _dbContext.Add(filmComment);
            _dbContext.SaveChanges();
        }
    }
}
