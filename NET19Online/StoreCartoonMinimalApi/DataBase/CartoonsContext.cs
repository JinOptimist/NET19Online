using Microsoft.EntityFrameworkCore;
using StoreCartoonMinimalApi.Model;

namespace StoreCartoonMinimalApi.DataBase
{
    public class CartoonsContex : DbContext
    {
        public const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Net19StoreCartoons;Integrated Security=True;";

        public DbSet<Cartoon> Cartoons { get; set; }

        public CartoonsContex() { }
        public CartoonsContex(DbContextOptions<CartoonsContex> option) : base(option) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }

    }
}
