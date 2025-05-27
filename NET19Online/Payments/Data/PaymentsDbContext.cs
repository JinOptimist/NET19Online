using Microsoft.EntityFrameworkCore;
using Payments.Data.Models;

namespace Payments.Data
{
    public class PaymentsDbContext :DbContext
    {
        public const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Net19StorePayments;Integrated Security=True;";

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Balance> Balance { get; set; }

        public PaymentsDbContext() { }
        public PaymentsDbContext(DbContextOptions<PaymentsDbContext> option) : base(option) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
    }
}
