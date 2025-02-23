using StoreData.Models;

namespace StoreData.Repostiroties;

public class LessonCommentRepository : BaseSchoolRepository<LessonCommentData>
{
    public LessonCommentRepository(SchoolDbContext dbContext) : base(dbContext) { }

    public void AddComment(int lessonId, string description)
    {
        var lesson = _dbContext.Lessons.First(l => l.Id == lessonId);
        var comment = new LessonCommentData()
        {
            Created = DateTime.UtcNow,
            Description = description,
            Lesson = lesson,
            LessonId = lessonId
        };
        _dbContext.Add(comment);
        _dbContext.SaveChanges();
    }
}