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
    public class NotebooksController : Controller   // Контролер отвечает за то, чтобы принять запрос от клиента. Передать запрос экшену. Экшен формирует viewModels, передаёт на Views
    {
        private NotebookGenerator _notebookGenerator;
        private NotebookRepository _notebookRepository;

        public NotebooksController(NotebookGenerator notebookGenerator, NotebookRepository notebookRepository)
        {
            _notebookGenerator = notebookGenerator;
            _notebookRepository = notebookRepository;
        }

        public IActionResult CreateOrderForNotebooks()
        {
            var notebookDatas = _notebookRepository.GetNotebooks();
            if (!notebookDatas.Any())
            {
                _notebookGenerator
                    .GenerateNotebook(5)
                    .Select(x =>
                    new NotebookData
                    {
                        Name = x.Name,
                        Src = x.Src
                    })
                    .ToList()
                    .ForEach(_notebookRepository.AddNotebook);
                notebookDatas = _notebookRepository.GetNotebooks();
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
            _notebookRepository.AddNotebook(
                new NotebookData
                {
                    Name = viewModel.Name,
                    Src = viewModel.Src
                });
            return RedirectToAction(nameof(CreateOrderForNotebooks));
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
