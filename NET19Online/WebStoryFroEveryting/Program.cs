using Microsoft.EntityFrameworkCore;
using StoreData;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.UnderwaterHuntersWorld;
using WebStoryFroEveryting.Services;
using WebStoryFroEveryting.Services.UnderwaterHunterServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(x => x.UseSqlServer(StoreDbContext.CONNECTION_STRING));
builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(SchoolDbContext))));
builder.Services.AddScoped<NameNotebookGenerator>();
builder.Services.AddScoped<NotebookGenerator>();

builder.Services.AddScoped<NotebookRepository>();

builder.Services.AddScoped<NameGenerator>();
builder.Services.AddScoped<IdolGenerator>();
builder.Services.AddScoped<LessonRepository>();

builder.Services.AddScoped<GamingDeviceGenerator>();
builder.Services.AddScoped<GamingDeviceRepository>();

builder.Services.AddScoped<IdolRepository>();
builder.Services.AddScoped<PlayerRepository>();
builder.Services.AddScoped<JerseyGenerator>();
builder.Services.AddScoped<JerseyRepository>();

builder.Services.AddScoped<MagicItemGenerator>();
builder.Services.AddScoped<MagicItemCategoryGenerator>();
builder.Services.AddScoped<MagicItemNameGenerator>();

builder.Services.AddScoped<MagicItemRepository>();

builder.Services.AddScoped<TheBestUnderwaterHunters>();
builder.Services.AddScoped<HuntersGenerator>();
builder.Services.AddScoped<UnderwarterHunterRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
