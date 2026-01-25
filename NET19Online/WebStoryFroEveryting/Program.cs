using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using StoreData;
using StoreData.Repostiroties;
using StoreData.Repostiroties.School;
using WebStoryFroEveryting.CustomMiddlewareServices;
using WebStoryFroEveryting.Hubs;
using WebStoryFroEveryting.Models.UnderwaterHuntersWorld;
using WebStoryFroEveryting.Services;
using WebStoryFroEveryting.Services.Apis;
using WebStoryFroEveryting.Services.Apis.UnderwaterHunterApi;
using WebStoryFroEveryting.Services.FilmsServer;
using WebStoryFroEveryting.Services.JerseyServices;
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

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var autoRegistrator = new AutoRegistrator(builder.Services);
autoRegistrator.RegisterRepositories(typeof(BaseRepository<>), typeof(IBaseRepository<>));
autoRegistrator.RegisterRepositories(typeof(BaseSchoolRepository<>));
autoRegistrator.RegisterServiceByAttribute();
autoRegistrator.RegisterServiceByAttributeOnConstructor();

builder.Services.AddScoped<NameNotebookGenerator>();
builder.Services.AddScoped<NotebookGenerator>();
builder.Services.AddScoped<INameGenerator, NameGenerator>();
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
builder.Services.AddScoped<JerseyApiReflectionWatcher>();

builder.Services.AddHttpClient<HttpNumberApi>(httpClient =>
{
    httpClient.BaseAddress = new Uri("http://numbersapi.com/");
});

builder.Services.AddHttpClient<HttpJokerApi>(http =>
{
    http.BaseAddress = new Uri("https://official-joke-api.appspot.com/");
});

builder.Services.AddHttpClient<HttpQuoteApi>(http =>
{
    http.BaseAddress = new Uri("https://favqs.com/api/qotd");
});

builder.Services.AddHttpClient<HttpWeatherApi>(http =>
{
    http.BaseAddress = new Uri("https://api.open-meteo.com/v1/forecast");
});

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
app.MapHub<GamingDeviceHub>("/hub/device");
app.MapHub<HunterHub>("/hub/hunter");
app.MapHub<PlayerHub>("/hub/player");
app.MapHub<JerseyChatHub>("/hub/jerseychat");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseSession();
app.Run();

