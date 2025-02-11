using StoreData.Repostiroties;
using WebStoryFroEveryting.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<NameNotebookGenerator>();
builder.Services.AddScoped<NotebookGenerator>();

builder.Services.AddScoped<NotebookRepository>();

builder.Services.AddScoped<NameGenerator>();
builder.Services.AddScoped<IdolGenerator>();

builder.Services.AddScoped<IdolRepository>();

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
