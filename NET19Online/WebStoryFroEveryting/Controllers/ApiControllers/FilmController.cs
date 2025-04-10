﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.AnimeGirl;
using WebStoryFroEveryting.Models.Films;

namespace WebStoryFroEveryting.Controllers.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private FilmsRepository _filmsRepository;
        public FilmController(FilmsRepository filmsRepository)
        {
            _filmsRepository = filmsRepository;
        }

        [HttpPost]
        public bool UpdateName(int id, string newName)
        {
            _filmsRepository.UpdateFilm(id, newName);
            return true;
        }
        [HttpPost]
        public void DeleteMovie(int id)
        {
            _filmsRepository.Remove(id);
        }

        [HttpPost]
        public int Create([FromForm] CreateFilmsViewModel viewModel)
        {

            var films = new FilmData
            {
                Name = viewModel.Name,
                Src = viewModel.Src,
            };

            _filmsRepository.Add(films);
            return films.Id;
        }

    }
}
