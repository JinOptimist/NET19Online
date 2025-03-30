using Microsoft.EntityFrameworkCore;
using ÑonstructionTools_StoreAPI.DataBase;
using ÑonstructionTools_StoreAPI.DataBase.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ConconstructionToolsStoreContext>(
   sq => sq.UseSqlServer(ConconstructionToolsStoreContext.CONNECTION_STRING));

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

app.MapGet("/addTool", (ConconstructionToolsStoreContext dbContext, string name, string description, string src, decimal price) =>
{
    var tool = new Tool
    {
        Name = name,
        Description = description,
        Src = src,
        Price = price
    };
    dbContext.Add(tool);
    dbContext.SaveChanges();
});

app.MapGet("/getTools",(ConconstructionToolsStoreContext dbContext) =>
{
    return dbContext.Tools.ToList();  
});

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
