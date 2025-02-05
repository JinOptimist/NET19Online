// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var list = new List<User>();
list.Add(new User
{
    Id = 1,
    IsAdmin = true,
    Name = "Ivan"
});
list.Add(new User
{
    Id = 2,
    IsAdmin = false,
    Name = "Liza"
});
list.Add(new User
{
    Id = 3,
    IsAdmin = true,
    Name = "Lera"
});

var answer = list
    .Where(x => x.IsAdmin && x.Name != "Ivan")
    .OrderBy(x => x.Name)
    .Skip(10)
    .Take(5);


public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsAdmin { get; set; }
}