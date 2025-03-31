using Microsoft.EntityFrameworkCore;
using SwapMeetProductMinimalApi.SwapMeetProductStoreData.Models;

namespace SwapMeetProductMinimalApi.SwapMeetProductStoreData
{
    public class SwapMeetProductDbContext : DbContext
    {
        public const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Net19SwapMeetProduct;Integrated Security=True;";

        public DbSet<SwapMeetProduct> SwapMeetProducts { get; set; }

        public SwapMeetProductDbContext() { }
        public SwapMeetProductDbContext(DbContextOptions<SwapMeetProductDbContext> option) : base(option) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
    }
}
