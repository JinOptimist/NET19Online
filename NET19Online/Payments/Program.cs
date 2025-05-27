using Microsoft.EntityFrameworkCore;
using Payments.Data;
using Payments.Data.Models;
using Payments.DTO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PaymentsDbContext>(
    op => op.UseSqlServer(PaymentsDbContext.CONNECTION_STRING));

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


app.MapPost("/addBalance", async (PaymentsDbContext dbContext, AddBalanceRequest request) =>
{
    var balance = new Balance
    {
        OwnerId = request.OwnerId,
        Total = request.Amount
    };

    await dbContext.Balance.AddAsync(balance);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.MapPost("/addTransaction", async (PaymentsDbContext dbContext, AddTransactionRequest request) =>
{
    var balance = await dbContext.Balance.FirstOrDefaultAsync(b => b.OwnerId == request.OwnerId);

    if (balance == null || balance.Total < request.Total)
    {
        return Results.StatusCode(416);
    }

    balance.Total -= request.Total;
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.MapGet("/getBalance/{id}", async (PaymentsDbContext dbContext, int id) =>
{
    var balance = await dbContext.Balance.FirstOrDefaultAsync(b => b.OwnerId == id);
    return balance is not null ? Results.Ok(balance) : Results.NotFound();
});

app.Run();
