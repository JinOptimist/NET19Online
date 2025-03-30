namespace ReflectionExample
{
    public class Manga
    {
        public string Name { get; set; }
        //private string _name;
        //public void SetName(string name)
        //{
        //    _name = name;
        //}
        //public string GetName()
        //{
        //    return _name;
        //}


        private int _yearOfRelease;


        private readonly int magicNumber = 1;

        public const int NOT_MAGIC_NUMBER = 2;

        public Manga()
        {

        }

        public Manga(string name, int yearOfRelease = 1000)
        {
            Name = name;
            _yearOfRelease = yearOfRelease;
        }

        public int HowOldAreYou()
        {
            return DateTime.Now.Year - _yearOfRelease + NOT_MAGIC_NUMBER - magicNumber;
        }

        public bool IsItGood(
            string nameOfPublisher, 
            int countOfViewers = 100, 
            Ranobe baseOfThisRanobe = null)
        {
            return true;
        }
    }
}
