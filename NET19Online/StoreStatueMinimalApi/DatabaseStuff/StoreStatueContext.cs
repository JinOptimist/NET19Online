using Microsoft.EntityFrameworkCore;
using StoreStatueMinimalApi.DatabaseStuff.Models;

namespace StoreStatueMinimalApi.DatabaseStuff
{
    public class StoreStatueContext : DbContext
    {
        public const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Net19StoreStatue;Integrated Security=True;";

        public DbSet<Statue> Statues { get; set; }

        public StoreStatueContext() { }
        public StoreStatueContext(DbContextOptions<StoreStatueContext> option) : base(option) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
    }
}
