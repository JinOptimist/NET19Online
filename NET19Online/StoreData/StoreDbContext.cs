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
        public DbSet<NotebookData> Notebooks { get; set; }
        public DbSet<NotebookCommentData> NotebookComments { get; set; }
        public DbSet<MagicItemData> MagicItems { get; set; }
        public DbSet<MagicItemCommentData> MagicItemComments { get; set; }
        public DbSet<MagicItemTagData> MagicItemTags { get; set; }
        public DbSet<FilmData> Films { get; set; }
        public DbSet<FilmCommentData> FilmCommentDatas { get; set; }
        public DbSet<DescriptionFilmData> DescriptionFilms { get; set; }
        public DbSet<UnderwaterHunterData> UnderwaterHunters { get; set; }

        public DbSet<UnderwaterHunterCommentData> UnderwaterHunterComments { get; set; }
        public DbSet<UnderwaterHunterTagData> UnderwaterHunterTags { get; set; }
        public DbSet<SweetsData> Sweets { get; set; } 


        public DbSet<GamingDeviceData> GamingDevices { get; set; }
        public DbSet<GamingDeviceReviewData> GamingDeviceReviews { get; set; }
        public DbSet<GamingDeviceStockData> GamingDeviceStocks { get; set; }

        public DbSet<JerseyData> Jerseys { get; set; }
        public DbSet<JerseyTagData> JerseysTags { get; set; }
        public DbSet<JerseyCommentData> JerseysComments { get; set; }
        public DbSet<PlayerData> FootballPlayers { get; set; }
        public DbSet<RoleData> Roles { get; set; }
        public DbSet<UserData> Users { get; set; }
        public DbSet<PlayerDescriptionData> PlayerDescriptions { get; set; }
        public DbSet<PlayerTagData> PlayerTags { get; set; }


        public StoreDbContext() { }
        public StoreDbContext(DbContextOptions<StoreDbContext> option) : base(option) { }

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

            modelBuilder.Entity<FilmData>()
                .HasMany(filmData => filmData.Comments)
                .WithOne(coment => coment.Film)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FilmData>()
                .HasOne(films => films.DescriptionFilms)
                .WithOne(description => description.Films)
                .HasForeignKey<DescriptionFilmData>(f => f.Id);

            modelBuilder.Entity<IdolData>()
                .HasMany(x => x.Tags)
                .WithMany(x => x.Idols);

            modelBuilder.Entity<UnderwaterHunterData>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.Hunter);

            modelBuilder.Entity<UnderwaterHunterData>()
                .HasMany(x => x.Tags)
                .WithMany(x => x.Hunters);

            modelBuilder.Entity<JerseyData>()
                .HasMany(jersey => jersey.Comments)
                .WithOne(comment => comment.Jersey)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<JerseyData>()
                .HasMany(jersey => jersey.Tags)
                .WithMany(tags => tags.Jerseys);

            modelBuilder.Entity<MagicItemData>()
                .HasMany(idol => idol.Comments)
                .WithOne(comment => comment.MagicItem)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MagicItemData>()
                .HasMany(x => x.Tags)
                .WithMany(x => x.MagicItems);

            modelBuilder.Entity<UserData>()
                .HasMany(u => u.IdolComments)
                .WithOne(c => c.Author);
            
            modelBuilder.Entity<UserData>()
                .HasMany(u => u.HunterComments)
                .WithOne(c => c.Author);

            modelBuilder.Entity<UserData>()
                .HasOne(u => u.Role)
                .WithMany(c => c.Users)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserData>()
               .HasMany(u => u.JerseyComments)
               .WithOne(c => c.Author);

            modelBuilder.Entity<PlayerData>()
                .HasMany(player => player.Descriptions)
                .WithOne(description => description.Player)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlayerData>()
                .HasMany(player => player.Tags)
                .WithMany(tag => tag.Players);

            modelBuilder.Entity<UserData>()
                .HasMany(u => u.PlayerDescriptions)
                .WithOne(c => c.Author);

            base.OnModelCreating(modelBuilder);
        }
    }
}
