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

        public void AddComment(int filmid, string comment)
        {
            var filmComment = new FilmCommentData();
            filmComment.FilmId = filmid;
            filmComment.Comment = comment;
            filmComment.UserName = Environment.UserName;
            filmComment.Created = DateTime.Now;
            _dbContext.Add(filmComment);
            _dbContext.SaveChanges();
        }

        public void DeleteComment(int filmid)
        {
            var strSelectSql = @"SELECT FilmId,COUNT(*) cou, UserName FROM FilmCommentDatas
                                                                        WHERE FilmId = @FilmId
							                                            Group By  UserName,FilmId
                                                                        HAVING COUNT(*) > 1"
                                ;
            var result = _dbContext.Database.SqlQueryRaw<FilmCommentDataDto>(strSelectSql, new SqlParameter("@FilmId", filmid)).ToList();
            var strDeleteSql = @"DELETE TOP (@Limit) 
                    FROM FilmCommentDatas 
                    WHERE FilmId = @FilmId";
            if (result[0]?.Cou>1)
            {
                _dbContext.Database.ExecuteSqlRaw(strDeleteSql, new SqlParameter("@FilmId", filmid), new SqlParameter("@Limit", (result[0].Cou - 1)));
            }
        }

    }
}
