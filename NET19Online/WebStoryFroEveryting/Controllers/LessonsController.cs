using Microsoft.AspNetCore.Mvc;
using WebStoryFroEveryting.Models.Lessons;

namespace WebStoryFroEveryting.Controllers;

public class LessonsController : Controller
{
    // Вынести 
    List<LessonViewModel> lessons = new List<LessonViewModel>
    {
        new LessonViewModel()
        {
            Id = 1,
            Title = "Переменные и типы данных",
            Source = "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/44sBcVvn-eI?si=nB0zvkicLKgUHMzp\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" referrerpolicy=\"strict-origin-when-cross-origin\" allowfullscreen></iframe>",
            Preview = "https://cdni.iconscout.com/illustration/premium/thumb/404-illustration-download-in-svg-png-gif-file-formats--error-not-found-page-result-webpage-pack-user-interface-illustrations-5974976.png?f=webp"
        },
        new LessonViewModel()
        {
            Id = 2,
            Title = "Условные операторы",
            Source = "https://www.youtube.com/watch?v=JD3Ois6i298&list=PLQOaTSbfxUtD6kMmAYc8Fooqya3pjLs1N&index=6",
            Preview = "https://cdni.iconscout.com/illustration/premium/thumb/404-illustration-download-in-svg-png-gif-file-formats--error-not-found-page-result-webpage-pack-user-interface-illustrations-5974976.png?f=webp"
        },
        new LessonViewModel()
        {
            Id = 3,
            Title = "Циклы",
            Source = "https://www.youtube.com/watch?v=JD3Ois6i298&list=PLQOaTSbfxUtD6kMmAYc8Fooqya3pjLs1N&index=6",
            Preview = "https://cdni.iconscout.com/illustration/premium/thumb/404-illustration-download-in-svg-png-gif-file-formats--error-not-found-page-result-webpage-pack-user-interface-illustrations-5974976.png?f=webp"
        },
        new LessonViewModel()
        {
            Id = 4,
            Title = "Методы",
            Source = "https://www.youtube.com/watch?v=JD3Ois6i298&list=PLQOaTSbfxUtD6kMmAYc8Fooqya3pjLs1N&index=6",
            Preview = "https://cdni.iconscout.com/illustration/premium/thumb/404-illustration-download-in-svg-png-gif-file-formats--error-not-found-page-result-webpage-pack-user-interface-illustrations-5974976.png?f=webp"
        },
        new LessonViewModel()
        {
            Id = 5,
            Title = "Методы",
            Source = "https://www.youtube.com/watch?v=JD3Ois6i298&list=PLQOaTSbfxUtD6kMmAYc8Fooqya3pjLs1N&index=6",
            Preview = "https://cdni.iconscout.com/illustration/premium/thumb/404-illustration-download-in-svg-png-gif-file-formats--error-not-found-page-result-webpage-pack-user-interface-illustrations-5974976.png?f=webp"
        },
        new LessonViewModel()
        {
            Id = 6,
            Title = "Методы",
            Source = "https://www.youtube.com/watch?v=JD3Ois6i298&list=PLQOaTSbfxUtD6kMmAYc8Fooqya3pjLs1N&index=6",
            Preview = "https://cdni.iconscout.com/illustration/premium/thumb/404-illustration-download-in-svg-png-gif-file-formats--error-not-found-page-result-webpage-pack-user-interface-illustrations-5974976.png?f=webp"
        },
        new LessonViewModel()
        {
            Id = 7,
            Title = "Методы",
            Source = "https://www.youtube.com/watch?v=JD3Ois6i298&list=PLQOaTSbfxUtD6kMmAYc8Fooqya3pjLs1N&index=6",
            Preview = "https://cdni.iconscout.com/illustration/premium/thumb/404-illustration-download-in-svg-png-gif-file-formats--error-not-found-page-result-webpage-pack-user-interface-illustrations-5974976.png?f=webp"
        },
    };
    public IActionResult Index()
    {

        return View(lessons);
    }

    public IActionResult Details(int id)
    {
        foreach (var item in lessons)
        {
            if (item.Id == id)
                return View(item);
        }

        throw new ArgumentException("Index not found");
    }
}