using Microsoft.EntityFrameworkCore;
using StoreData.Models;

namespace StoreData
{
    public class FilmsDbConntext : DbContext
    {
        public const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Net19Films;Integrated Security=True;Connect Timeout=30;";

        public DbSet<DateFilm> DateFilms { get; set; }
        public FilmsDbConntext() { }
        public FilmsDbConntext(DbContextOptions dbContext) : base(dbContext) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
    }
}
