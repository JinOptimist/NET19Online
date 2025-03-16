namespace WebStoryFroEveryting.Models.Singers
{
    public class SingerViewModel
    {
        public string Pseudonym { get; set; }

        public string Src {  get; set; }
        
        public string Style { get; set; }
        public string ErrorMessage { get; internal set; }
        public int Id { get; internal set; }
    }
}
