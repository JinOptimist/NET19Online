using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using WebStoryFroEveryting.Models.Notebook;
using static System.Net.Mime.MediaTypeNames;
using WebStoryFroEveryting.Services;
using StoreData.Repostiroties;
using StoreData.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebStoryFroEveryting.Controllers
{
    public class NotebooksController : Controller   
    {
        private NotebookGenerator _notebookGenerator;
        private NotebookRepository _notebookRepository;
        private NotebookCommentRepository _notebookCommentRepository;
        private AuthService _authService;

        public NotebooksController(NotebookGenerator notebookGenerator,
            NotebookRepository notebookRepository,
            NotebookCommentRepository notebookCommentRepository,
            AuthService authService)
        {
            _notebookGenerator = notebookGenerator;
            _notebookRepository = notebookRepository;
            _notebookCommentRepository = notebookCommentRepository;
            _authService = authService;
        }

        public IActionResult Index(string? tag)
        {
            var notebookDatas = _notebookRepository.GetAllWithTags(tag);
            if (!notebookDatas.Any())
            {
                _notebookGenerator
                    .GenerateNotebook(7)
                    .Select(viewModel =>
                    new NotebookData
                    {
                        Name = viewModel.Name,
                        Src = viewModel.Src
                    })
                    .ToList()
                    .ForEach(_notebookRepository.Add);
                notebookDatas = _notebookRepository.GetAll();
            }

            
            var viewModel = new NotebookIndexViewModel();
            viewModel.Notebooks = notebookDatas.Select(Map).ToList();
            viewModel.Tags = notebookDatas
                .SelectMany(x => x.Tags)
                .Select(x=>x.Tag)
                .Distinct()
                .ToList();
            viewModel.CurrentTag = tag;
            viewModel.CanUserFillters = _authService.IsAuthenticated();
            return View(viewModel);
        }
         
        public IActionResult Remove(int id)
        {
            _notebookRepository.Remove(id);
            return RedirectToAction(nameof(Index));    
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateNotebookViewModel viewModel)        
        {
            _notebookRepository.Add(
                new NotebookData
                {
                    Name = viewModel.Name,
                    Src = viewModel.Src
                });
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CommentForNotebook(int notebookId)
        {
            var viewModel = new NotebookWithCoomentViewModel();
            
            var notebook = _notebookRepository.GetWithCommentsAndTags(notebookId);

            viewModel.Id = notebook.Id;
            viewModel.Src = notebook.Src;
            viewModel.Comments = notebook
                .Comments
                .Select(x => new NotebookCoomentViewModel
            {
                Id = x.Id,
                Comment = x.Comment,
                Created = x.Created
            })
                .ToList(); 
            viewModel.Tags = notebook.Tags.Select(x => x.Tag).ToList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddComment(int notebookId, string comment)
        {
            _notebookCommentRepository.AddComment(notebookId, comment);

            return RedirectToAction(nameof(CommentForNotebook), new { notebookId });
        }

        [HttpPost]
        public IActionResult AddTag(int notebookId, string tag) 
        {
            _notebookRepository.AddTag(notebookId, tag);

            return RedirectToAction(nameof(CommentForNotebook), new { notebookId });
        }
        private NotebookViewModel Map(NotebookData notebook)
        {
            return new NotebookViewModel
            {
                Id = notebook.Id,
                Src = notebook.Src,
                Name = notebook.Name,
            };
        }
    }
}
