using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.Lessons;

namespace WebStoryFroEveryting.Controllers;

public class LessonsController: Controller
{
    private readonly LessonRepository _lessonRepository;

    public LessonsController(LessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }
    public IActionResult Index()
    {
        var lessonsData = _lessonRepository.GetAll();
        var lessons = lessonsData
            .Select(MapToViewModel)
            .ToList();
        return View(lessons);
    }

    public IActionResult Details(int id)
    {
        var result = _lessonRepository.Get(id);

        if (result == null)
        {
            throw new ArgumentException("Id not found");
        }

        return View(MapToViewModel(result));

    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(LessonViewModel lessonViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(lessonViewModel);
        }
        _lessonRepository.Add(new LessonData()
        {
            Title = lessonViewModel.Title,
            Preview = lessonViewModel.Preview,
            Source = lessonViewModel.Source,
            Level = lessonViewModel.Level
        });
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Remove(int id)
    {
        _lessonRepository.Remove(id);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Update(int id)
    {
        var result = _lessonRepository.Get(id);

        if (result == null)
        {
            throw new ArgumentException("Id not found");
        }

        return View(MapToViewModel(result));
    }
    
    [HttpPost]
    public IActionResult Edit(LessonViewModel lessonViewModel)
    {
        _lessonRepository.Update(MapToData(lessonViewModel));
        return RedirectToAction(nameof(Index));
    }
    
    private LessonViewModel MapToViewModel(LessonData lessonData)
    {
        return new LessonViewModel()
        {
            Id = lessonData.Id,
            Preview = lessonData.Preview,
            Source = lessonData.Source,
            Title = lessonData.Title,
        };
    }
    
    private LessonData MapToData(LessonViewModel lessonViewModel)
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