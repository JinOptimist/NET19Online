namespace StoreData.Models;

public class LessonData : BaseModel
{
    public string Title { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string Preview { get; set; } = string.Empty;
}