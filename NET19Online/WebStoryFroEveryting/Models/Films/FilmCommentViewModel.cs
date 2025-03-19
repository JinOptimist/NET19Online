namespace WebStoryFroEveryting.Models.Films
{
    public class FilmCommentViewModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
        public string? UserName { get; set; }
        public FilmCommentViewModel FilmComment { get; set; }
    }
}
