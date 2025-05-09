﻿using StoreData.Models;

namespace WebStoryFroEveryting.Models.Films
{
    public class FilmsViewModel
    {
        public int id { get; set; }
        public DateTime DateFilm { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Src { get; set; }
        public virtual List<FilmCommentViewModel>? Comments { get; set; }
        public virtual DescriptionFilmViewModel? DescriptionFilm { get; set; }
    }
}
