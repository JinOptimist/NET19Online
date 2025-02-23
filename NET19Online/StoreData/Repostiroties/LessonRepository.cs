using Microsoft.EntityFrameworkCore;
using StoreData.Models;

namespace StoreData.Repostiroties;

public class LessonRepository : BaseSchoolRepository<LessonData>
{
    public LessonRepository(SchoolDbContext dbContext) : base(dbContext) { }
    public override LessonData Get(int id)
    {
        return _dbSet
            .AsNoTracking()
            .Include(l => l.Comments)
            .First(x => x.Id == id);
    }
}