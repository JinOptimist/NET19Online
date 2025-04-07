using Microsoft.EntityFrameworkCore;
using StoreCartoonMinimalApi.DataBase;
using StoreCartoonMinimalApi.Model;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CartoonsContex>(op => op.UseSqlServer(CartoonsContex.CONNECTION_STRING));
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

// Routing
app.MapGet("/addCartoons",
    (CartoonsContex dbContext, string name, string src) =>
    {
        var cartoon = new Cartoon
        {
            Name = name,
            Src = src
        };
        dbContext.Cartoons.Add(cartoon);
        dbContext.SaveChanges();
    });

app.MapGet("/getCartoons",
    (CartoonsContex dbContext) =>
    {
        var result = dbContext.Cartoons.ToList();
        return result;
    });

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
