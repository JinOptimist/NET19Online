using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoreData.Models;

namespace StoreData.Repostiroties
{
    public class GamingDeviceReviewRepository : BaseRepository<GamingDeviceReviewData>
    {
        public GamingDeviceReviewRepository(StoreDbContext dbContext) : base(dbContext) { }

        public void AddReview(int deviceId, string review, int authorId)
        {
            var device = _dbContext.GamingDevices.First(x => x.Id == deviceId);
            var user = _dbContext.Users.First(x => x.Id == authorId);

            var deviceReview = new GamingDeviceReviewData
            {
                Created = DateTime.Now,
                Review = review,
                GamingDevice = device,
                Author = user
            };

            Add(deviceReview);
        }

        public void RemoveDuplicateReviews(int deviceId)
        {
            var strSelectSql = @" DELETE FROM GamingDeviceReviews
                        WHERE Id NOT IN (
                            SELECT MIN(Id)
                            FROM GamingDeviceReviews
                            WHERE GamingDeviceId = @deviceId
                            GROUP BY AuthorId, GamingDeviceId, Review
                        );";
            var result = _dbContext.Database.ExecuteSqlRaw(strSelectSql, new SqlParameter("@deviceId", deviceId));
        }
    }
}
