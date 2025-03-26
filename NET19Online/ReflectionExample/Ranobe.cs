namespace ReflectionExample
{
    public class Ranobe
    {
        public string Name { get; set; }  
        public string Description { get; set; }
        public string Genre { get; set; }

        public Ranobe() { }

        public Ranobe(string name)
        {
            Name = name;
        }

        public Ranobe(string name, string description, string genre) : this(name)
        {
            Description = description;
            Genre = genre;
        }
    }
}
