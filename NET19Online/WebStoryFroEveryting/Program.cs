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

var autoRegistrator = new AutoRegistrator();
autoRegistrator.RegisterRepositories(builder.Services, typeof(BaseRepository<>));
autoRegistrator.RegisterRepositories(builder.Services, typeof(BaseSchoolRepository<>));

builder.Services.AddScoped<NameNotebookGenerator>();
builder.Services.AddScoped<NotebookGenerator>();
//builder.Services.AddScoped<NotebookRepository>();
//builder.Services.AddScoped<NotebookCommentRepository>();

builder.Services.AddScoped<NameGenerator>();
builder.Services.AddScoped<IdolGenerator>();
builder.Services.AddScoped<FilmsGeneratorServices>();

//builder.Services.AddScoped<RoleRepository>();
//builder.Services.AddScoped<IdolRepository>();
//builder.Services.AddScoped<FilmsRepository>();
//builder.Services.AddScoped<FilmCommentRepository>();
//builder.Services.AddScoped<LessonRepository>();

//builder.Services.AddScoped<LessonRepository>();
//builder.Services.AddScoped<LessonCommentRepository>();
//builder.Services.AddScoped<BanWordRepository>();
//builder.Services.AddScoped<BannedUserRepository>();
builder.Services.AddScoped<FilmsGeneratorServices>();

//builder.Services.AddScoped<FilmsRepository>();
//builder.Services.AddScoped<LessonRepository>();


builder.Services.AddScoped<GamingDeviceGenerator>();
//builder.Services.AddScoped<GamingDeviceRepository>();
//builder.Services.AddScoped<GamingDeviceReviewRepository>();

//builder.Services.AddScoped<IdolRepository>();
//builder.Services.AddScoped<IdolCommentRepository>();
//builder.Services.AddScoped<PlayerRepository>();
//builder.Services.AddScoped<PlayerDescriptionRepository>();
builder.Services.AddScoped<JerseyGenerator>();
//builder.Services.AddScoped<JerseyRepository>();
//builder.Services.AddScoped<JerseyCommentRepository>();

builder.Services.AddScoped<MagicItemGenerator>();
builder.Services.AddScoped<MagicItemCategoryGenerator>();
builder.Services.AddScoped<MagicItemNameGenerator>();

//builder.Services.AddScoped<MagicItemRepository>();
//builder.Services.AddScoped<MagicItemCommentRepository>();

builder.Services.AddScoped<UnderwaterHunterViewModel>();
builder.Services.AddScoped<HuntersGenerator>();
//builder.Services.AddScoped<UnderwarterHunterRepository>();
//builder.Services.AddScoped<UnderwarterHunterCommentRepository>();
//builder.Services.AddScoped<SingerRepository>();
//builder.Services.AddScoped<UserRepository>();
//builder.Services.AddScoped<SchoolUserRepository>();
//builder.Services.AddScoped<SchoolRoleRepository>();
builder.Services.AddScoped<SchoolAuthService>();

builder.Services.AddScoped<AuthService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<SweetsNameGenerator>();
builder.Services.AddScoped<SweetsModelGenerator>();
//builder.Services.AddScoped<SweetsRepository>();



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

