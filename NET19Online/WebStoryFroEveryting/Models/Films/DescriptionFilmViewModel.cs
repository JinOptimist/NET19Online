namespace WebStoryFroEveryting.Models.Films
{
    public class DescriptionFilmViewModel
    {
        public int Id { get; set; }
        public string? DescriptionFilm { get; set; }
        public DateTime CreatedDate { get; set; }
        public FilmsViewModel Films { get; set; } = new FilmsViewModel();

    }
}
