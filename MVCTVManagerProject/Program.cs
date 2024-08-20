using TVManager_Domain;
using TVManager_Infrastructre.Interfaces;
using TVManager_Infrastructure;
using TVManager_Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRepository<Language>, GenericRepository<Language>>();
builder.Services.AddScoped<IRepository<Attachment>, GenericRepository<Attachment>>();
builder.Services.AddScoped<IRepository<TVShow>, GenericRepository<TVShow>>();
builder.Services.AddDbContext<TVManagerDBContext>(ServiceLifetime.Scoped);

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
