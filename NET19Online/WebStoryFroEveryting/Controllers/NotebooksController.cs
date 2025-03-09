using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using WebStoryFroEveryting.Models.Notebook;
using static System.Net.Mime.MediaTypeNames;
using WebStoryFroEveryting.Services;
using StoreData.Repostiroties;
using StoreData.Models;

namespace WebStoryFroEveryting.Controllers
{
    public class NotebooksController : Controller   
    {
        private NotebookGenerator _notebookGenerator;
        private NotebookRepository _notebookRepository;
        private NotebookCommentRepository _notebookCommentRepository;

        public NotebooksController(NotebookGenerator notebookGenerator, 
            NotebookRepository notebookRepository, 
            NotebookCommentRepository notebookCommentRepository)
        {
            _notebookGenerator = notebookGenerator;
            _notebookRepository = notebookRepository;
            _notebookCommentRepository = notebookCommentRepository;
        }

        public IActionResult CreateOrderForNotebooks()
        {
            var notebookDatas = _notebookRepository.GetAll();
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

            var viewModels = notebookDatas.Select(Map).ToList();
            return View(viewModels);
        }

        public IActionResult Remove(int id)
        {
            _notebookRepository.Remove(id);
            return RedirectToAction(nameof(CreateOrderForNotebooks));    
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateNotebookViewModel viewModel)        
        {
            _notebookRepository.Add(
                new NotebookData
                {
                    Name = viewModel.Name,
                    Src = viewModel.Src
                });
            return RedirectToAction(nameof(CreateOrderForNotebooks));
        }

        public IActionResult CommentForNotebook(int notebookId)
        {
            var viewModel = new NotebookWithCoomentViewModel();
            
            var notebook = _notebookRepository.GetWithComments(notebookId);

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

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddComment(int notebookId, string comment)
        {
            _notebookCommentRepository.AddComment(notebookId, comment);

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
