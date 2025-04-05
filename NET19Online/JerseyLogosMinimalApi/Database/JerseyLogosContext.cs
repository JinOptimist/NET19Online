using JerseyLogosMinimalApi.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace JerseyLogosMinimalApi.Database
{
    public class JerseyLogosContext: DbContext
    {
        public const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Net19JerseyLogos;Integrated Security=True;";
        public DbSet<Logo> Logos { get; set; }
        public JerseyLogosContext(DbContextOptions<JerseyLogosContext> options) : base(options)
        {
        }

        public JerseyLogosContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
    }
}
