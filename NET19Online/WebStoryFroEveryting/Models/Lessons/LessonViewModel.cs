using StoreData.Attributes;

namespace WebStoryFroEveryting.Models.Lessons;

public class LessonViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    [YouTubeUri]
    public string Source { get; set; }
    
    [ImageUri]
    public string Preview { get; set; }
}