using Microsoft.EntityFrameworkCore;
using StoreData.Models;

namespace StoreData
{
    public class FilmsDbContext : DbContext
    {
        public const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Net19Films;Integrated Security=True;Connect Timeout=30;";

        public DbSet<DateFilm> DateFilms { get; set; }
        public FilmsDbContext() { }
        public FilmsDbContext(DbContextOptions dbContext) : base(dbContext) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
    }
}
