using JerseyLogosMinimalApi.Database;
using JerseyLogosMinimalApi.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace JerseyLogosMinimalApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<JerseyLogosContext>(
                op => op.UseSqlServer(JerseyLogosContext.CONNECTION_STRING));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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


            app.MapGet("/", () => "Hello World!");
            app.MapGet(
                "/addlogo", 
                (JerseyLogosContext dbContext, string clubName, string img) =>
                {
                    var logo = new Logo
                    {
                        ClubName = clubName,
                        Img = img
                    };
                    dbContext.Logos.Add(logo);
                    dbContext.SaveChanges();
                });
            app.MapGet(
               "/getlogos",
               (JerseyLogosContext dbContext) =>
               {
                   
                   return dbContext.Logos.ToList();
                });
            app.MapGet(
               "/deletelogo",
               (JerseyLogosContext dbContext, int id) =>
               {
                   var logo = dbContext.Logos.First(x => x.Id == id);
                   dbContext.Logos.Remove(logo);
                   dbContext.SaveChanges();
               });

            app.UseSwagger();
            app.UseSwaggerUI();
            app.Run();
        }
    }
}
