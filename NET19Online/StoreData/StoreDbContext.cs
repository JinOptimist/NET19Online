using Microsoft.EntityFrameworkCore;
using StoreData.Models;

namespace StoreData
{
    public class StoreDbContext : DbContext
    {
        public const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Net19Store;Integrated Security=True;";

        public DbSet<IdolData> Idols { get; set; }
        public DbSet<MagicItemData> MagicItems { get; set; }
        public DbSet<JerseyData> Jerseys { get; set; }
        public DbSet<PlayerData> FootballPlayers { get; set; }


        public StoreDbContext() { }
        public StoreDbContext(DbContextOptions option) : base(option) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
    }
}
