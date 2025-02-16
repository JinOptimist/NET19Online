using System.ComponentModel.DataAnnotations;

namespace StoreData.Models;

public enum Level
{
    [Display(Name = "Начинающий")]
    Beginner,
    [Display(Name = "Базовый")]
    Base,
    [Display(Name = "Продвинутый")]
    Advanced,
}

public class LessonData : BaseModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string Preview { get; set; } = string.Empty;
    
    public Level Level { get; set; }
}