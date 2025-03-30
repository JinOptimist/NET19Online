using Microsoft.EntityFrameworkCore;
using СonstructionTools_StoreAPI.DataBase.Models;
namespace СonstructionTools_StoreAPI.DataBase
{
    public class ConconstructionToolsStoreContext : DbContext 
    {
        public const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Net19StoreConTools;Integrated Security=True;";
        public DbSet<Tool> Tools {  get; set; }
        public ConconstructionToolsStoreContext() { }
        public ConconstructionToolsStoreContext(DbContextOptions<ConconstructionToolsStoreContext> option) : base(option) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
       
    }
}
