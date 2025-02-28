using Enums.SchoolUser;
using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.Lessons;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEveryting.Controllers;

public class LessonsController: Controller
{
    private readonly LessonRepository _lessonRepository;
    private readonly LessonCommentRepository _commentRepository;
    private readonly SchoolAuthService _authService;

    public LessonsController(
        LessonRepository lessonRepository, 
        LessonCommentRepository lessonCommentRepository,
        SchoolAuthService authService)
    {
        _lessonRepository = lessonRepository;
        _commentRepository = lessonCommentRepository;
        _authService = authService;
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
        return View(MapToCommentViewModel(result));
    }

    [HttpGet]
    public IActionResult Create()
    {
        if (!_authService.HasPermission(SchoolPermission.CanAddLesson))
        {
            return Forbid();
        }
        return View();
    }

    [HttpPost]
    public IActionResult Create(LessonViewModel lessonViewModel)
    {
        if (!_authService.HasPermission(SchoolPermission.CanAddLesson))
        {
            return Forbid();
        }
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
    
    [HttpPost]
    public IActionResult CreateComment(int lessonId,int userId, string description)
    {
        _commentRepository.AddComment(lessonId,userId, description);
        return RedirectToAction(nameof(Details), new { id = lessonId });
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
    
    private LessonWithCommentViewModel MapToCommentViewModel(LessonData lessonData)
    {
        var commentsViewModel = lessonData.Comments
            .Select(c => new LessonCommentViewModel()
            {
                Created = c.Created,
                Description = c.Description,
                Id = c.Id,
                User = new SchoolUserViewModel(){Username = c.User.Username}
            })
            .ToList();
        return new LessonWithCommentViewModel()
        {
            Id = lessonData.Id,
            Preview = lessonData.Preview,
            Source = lessonData.Source,
            Title = lessonData.Title,
            Comments = commentsViewModel
        };
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