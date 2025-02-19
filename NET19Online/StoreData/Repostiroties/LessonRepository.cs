using StoreData.Models;

namespace StoreData.Repostiroties;

public class LessonRepository : BaseSchoolRepository<LessonData>
{
    public LessonRepository(SchoolDbContext dbContext) : base(dbContext) { }
    
}