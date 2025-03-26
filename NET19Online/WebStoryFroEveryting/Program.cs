using Microsoft.EntityFrameworkCore;
using StoreData;
using StoreData.Repostiroties;
using StoreData.Repostiroties.School;
using WebStoryFroEveryting.CustomMiddlewareServices;
using WebStoryFroEveryting.Hubs;
using WebStoryFroEveryting.Models.UnderwaterHuntersWorld;
using WebStoryFroEveryting.Services;
using WebStoryFroEveryting.Services.FilmsServer;
using WebStoryFroEveryting.Services.ReflectionServices;
using WebStoryFroEveryting.Services.UnderwaterHunterServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication(AuthService.AUTH_TYPE)
    .AddCookie(AuthService.AUTH_TYPE, config =>
    {
        config.LoginPath = "/Auth/Login";
        config.AccessDeniedPath = "/Auth/YouCanSeeIt";
    });

builder.Services
    .AddAuthentication(SchoolAuthService.AUTH_TYPE)
    .AddCookie(SchoolAuthService.AUTH_TYPE, config =>
    {
        config.LoginPath = "/SchoolAuth/Login";
    });

builder.Services.AddSignalR();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services
    .AddDbContext<StoreDbContext>(x => x.UseSqlServer(StoreDbContext.CONNECTION_STRING));
builder.Services
    .AddDbContext<SchoolDbContext>(
        options => options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(SchoolDbContext))));

var autoRegistrator = new AutoRegistrator(builder.Services);
autoRegistrator.RegisterRepositories(typeof(BaseRepository<>));
autoRegistrator.RegisterRepositories(typeof(BaseSchoolRepository<>));
autoRegistrator.RegisterServiceByAttribute();
autoRegistrator.RegisterServiceByAttributeOnConstructor();

builder.Services.AddScoped<NameNotebookGenerator>();
builder.Services.AddScoped<NotebookGenerator>();
builder.Services.AddScoped<NameGenerator>();
builder.Services.AddScoped<FilmsGeneratorServices>();
builder.Services.AddScoped<FilmsGeneratorServices>();
builder.Services.AddScoped<GamingDeviceGenerator>();
builder.Services.AddScoped<JerseyGenerator>();
builder.Services.AddScoped<MagicItemGenerator>();
builder.Services.AddScoped<MagicItemCategoryGenerator>();
builder.Services.AddScoped<MagicItemNameGenerator>();
builder.Services.AddScoped<UnderwaterHunterViewModel>();
builder.Services.AddScoped<HuntersGenerator>();
builder.Services.AddScoped<SchoolAuthService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<SweetsNameGenerator>();
builder.Services.AddScoped<SweetsModelGenerator>();

var app = builder.Build();

var seed = new Seed();
seed.CheckAndFillWithDefaultEntytiesDatabase(app.Services);

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

app.UseAuthentication(); // Who you are?
app.UseAuthorization();  // May I in?

app.UseMiddleware<LocalizationMiddleware>();

app.MapHub<ChatHub>("/hub/chat");
app.MapHub<IdolHub>("/hub/idol");
app.MapHub<HunterHub>("/hub/hunter");
app.MapHub<PlayerHub>("/hub/player");
app.MapHub<JerseyChatHub>("/hub/jerseychat");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

