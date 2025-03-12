using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoreData.CustomQueryModels;
using StoreData.Models;
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
        private const int USER = 1;
        public void AddComment(int filmid, string comment)
        {
            var filmComment = new FilmCommentData();
            filmComment.FilmId = filmid;
            filmComment.Comment = comment;
            filmComment.Created = DateTime.Now;
            _dbContext.Add(filmComment);
            _dbContext.SaveChanges();
        }

        public void DeleteComment(int filmid)
        {
            var strSelectSql = @" DELETE FROM FilmCommentDatas
                                              WHERE Id NOT IN (
                                                  SELECT MIN(Id)
                                                  FROM FilmCommentDatas
                                                  WHERE FilmId = @FilmId
                                                  GROUP BY UserId, FilmId, Comment
                                              );";
            var result = _dbContext.Database.ExecuteSqlRaw(strSelectSql, new SqlParameter("@FilmId", filmid));
        }

    }
}
