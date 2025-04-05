using Microsoft.EntityFrameworkCore;
using SwapMeetProductMinimalApi.SwapMeetProductStoreData;
using SwapMeetProductMinimalApi.SwapMeetProductStoreData.Models;

namespace SwapMeetProductMinimalApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<SwapMeetProductDbContext>
                             (op =>
                             op.UseSqlServer(SwapMeetProductDbContext.CONNECTION_STRING));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors(o =>
            {
                o.AddDefaultPolicy(p =>
                {
                    p.AllowAnyHeader();
                    p.AllowAnyMethod();
                    p.SetIsOriginAllowed(x => true);
                    p.AllowCredentials();
                });
            });

            var app = builder.Build();

            app.UseCors();

            app.MapGet("/", () => "Swap meet products site!");

            app.MapGet("/addProduct",
                (SwapMeetProductDbContext dbContext, string name,
                string description, string src, decimal price) =>
                {
                    var product = new SwapMeetProduct
                    {
                        Name = name,
                        Description = description,
                        Src = src,
                        Price = price
                    };
                    dbContext.SwapMeetProducts.Add(product);
                    dbContext.SaveChanges();
                });

            app.MapGet("/getProduct", (SwapMeetProductDbContext dbContext) =>
            {
                return dbContext
                      .SwapMeetProducts
                      .ToList();
            });

            app.Run();
        }
    }
}
