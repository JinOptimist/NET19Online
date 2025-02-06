using Microsoft.AspNetCore.Mvc;
using WebStoryFroEveryting.Models.Lessons;

namespace WebStoryFroEveryting.Controllers;

public class LessonsController : Controller
{
    public IActionResult Index()
    {
        var lessons = new List<LessonViewModel>
        {
            new LessonViewModel()
            {
                Id = 1,
                Title = "Переменные и типы данных",
                Source = "https://www.youtube.com/watch?v=JD3Ois6i298&list=PLQOaTSbfxUtD6kMmAYc8Fooqya3pjLs1N&index=6",
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
        };
        return View(lessons);
    }

    public IActionResult Details(int id)
    {
        return View();
    }
}