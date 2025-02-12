using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.Lessons;

namespace WebStoryFroEveryting.Controllers;

public class LessonsController(LessonRepository lessonRepository) : Controller
{
    private LessonRepository _lessonRepository = lessonRepository;

    public IActionResult Index()
    {
        var lessonsData = _lessonRepository.GetLessons();
        var lessons = new List<LessonViewModel> { };
        foreach (var item in lessonsData)
        {
            lessons.Add(Map(item));
        }
        return View(lessons);
    }

    public IActionResult Details(int id)
    {
        var result = _lessonRepository.GetLessonById(id);

        if (result == null)
        {
            throw new ArgumentException("Id not found");
        }

        return View(Map(result));

    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreatePost(LessonViewModel lessonViewModel)
    {
        _lessonRepository.InsertLesson(new LessonData()
        {
            Title = lessonViewModel.Title,
            Preview = lessonViewModel.Preview,
            Source = lessonViewModel.Source
        });
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Remove(int id)
    {
        _lessonRepository.DeleteLesson(id);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Update(int id)
    {
        var result = _lessonRepository.GetLessonById(id);

        if (result == null)
        {
            throw new ArgumentException("Id not found");
        }

        return View(Map(result));
    }
    
    [HttpPost]
    public IActionResult Edit(LessonViewModel lessonViewModel)
    {
        _lessonRepository.UpdateLesson(Map(lessonViewModel));
        return RedirectToAction(nameof(Index));
    }
    
    private LessonViewModel Map(LessonData lessonData)
    {
        return new LessonViewModel()
        {
            Id = lessonData.Id,
            Preview = lessonData.Preview,
            Source = lessonData.Source,
            Title = lessonData.Title,
        };
    }
    
    private LessonData Map(LessonViewModel lessonViewModel)
    {
        return new LessonData()
        {
            Id = lessonViewModel.Id,
            Preview = lessonViewModel.Preview,
            Source = lessonViewModel.Source,
            Title = lessonViewModel.Title,
        };
    }
}