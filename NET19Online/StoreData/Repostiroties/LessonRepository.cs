using StoreData.Models;

namespace StoreData.Repostiroties;

public class LessonRepository
{
    private static List<LessonData> _lessons = [];

    public List<LessonData> GetLessons()
    {
        return _lessons;
    }

    public LessonData? GetLessonById(int id)
    {
        var result = _lessons.Find(x => x.Id == id);
        if (result is null)
        {
            throw new ArgumentException("Id not found");
        }
        return result;
    }

    public void InsertLesson(LessonData lessonData)
    {
        lessonData.Id = _lessons.Count > 0
            ? _lessons.Max(x => x.Id) + 1
            : 1;
        _lessons.Add(lessonData);
    }

    public void DeleteLesson(int id)
    {
        _lessons = _lessons.Where(x => x.Id != id).ToList();
    }

    public void UpdateLesson(LessonData lessonData)
    {
        var result = _lessons
            .Find(x => x.Id == lessonData.Id);
        if (result == null)
        {
            throw new ArgumentException("Id not found");
        }
        result.Preview = lessonData.Preview;
        result.Title = lessonData.Title;
        result.Source = lessonData.Source;
    }
    
    
}