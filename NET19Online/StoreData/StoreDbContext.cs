using Microsoft.EntityFrameworkCore;
using StoreData.Models;

namespace StoreData
{
    public class StoreDbContext : DbContext
    {
        public const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Net19Store;Integrated Security=True;";

        public DbSet<IdolData> Idols { get; set; }
        public DbSet<IdolCommentData> IdolComments { get; set; }
        public DbSet<IdolTagData> IdolTags { get; set; }
        public DbSet<MagicItemData> MagicItems { get; set; }
        public DbSet<UnderwaterHunterData> UnderwaterHunters { get; set; }
        
        public DbSet<GamingDeviceData> GamingDevices { get; set; }

        public DbSet<JerseyData> Jerseys { get; set; }
        public DbSet<JerseyTagData> JerseysTags { get; set; }
        public DbSet<JerseyCommentData> JerseysComments { get; set; }
        public DbSet<PlayerData> FootballPlayers { get; set; }


        public StoreDbContext() { }
        public StoreDbContext(DbContextOptions option) : base(option) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdolData>()
                .HasMany(idol => idol.Comments)
                .WithOne(comment => comment.Idol)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<IdolData>()
                .HasMany(x => x.Tags)
                .WithMany(x => x.Idols);

            modelBuilder.Entity<JerseyData>()
                .HasMany(jersey => jersey.Comments)
                .WithOne(comment => comment.Jersey)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<JerseyData>()
                .HasMany(jersey => jersey.Tags)
                .WithMany(tags => tags.Jerseys);

            base.OnModelCreating(modelBuilder);
        }
    }
}
