using Microsoft.EntityFrameworkCore;
using StoreData.Models;

namespace StoreData;

public class SchoolDbContext : DbContext
{
    public const string CONNECTION_STRING = "User ID=postgres;Password=root;Host=localhost;Port=5432;Database=postgres;";

    public DbSet<LessonData> Lessons { get; set; }


    public SchoolDbContext() { }
    public SchoolDbContext(DbContextOptions option) : base(option) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(CONNECTION_STRING);
    }
}