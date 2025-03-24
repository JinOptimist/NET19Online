using Microsoft.EntityFrameworkCore;
using StoreStatueMinimalApi.DatabaseStuff;
using StoreStatueMinimalApi.DatabaseStuff.Models;

var builder = WebApplication.CreateBuilder(args);
// DI

builder.Services.AddDbContext<StoreStatueContext>(
    op => op.UseSqlServer(StoreStatueContext.CONNECTION_STRING));

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
// middleware
app.UseCors();


// Routing
app.MapGet("/", () => "Hello World!");
app.MapGet("/smile", () => "Smile too");

app.MapGet(
    "/addStatue",
    (StoreStatueContext dbContext, string name, string desc, string src, decimal cost) =>
    {
        var statue = new Statue
        {
            Cost = cost,
            Name = name,
            Description = desc,
            Src = src,
        };

        dbContext.Statues.Add(statue);
        dbContext.SaveChanges();
    });

app.MapGet(
    "/getStatues",
    (StoreStatueContext dbContext) =>
    {
        return dbContext.Statues.ToList();
    });

app.MapGet(
    "/deleteStatue", 
    (StoreStatueContext dbContext, int id) =>
    {
        var statue = dbContext.Statues.First(x => x.Id == id);
        dbContext.Statues.Remove(statue);
        dbContext.SaveChanges();
    });

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
