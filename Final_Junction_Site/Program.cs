using Microsoft.EntityFrameworkCore;
using Final_Junction_Site.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add when Rating Interface and Repository are created
builder.Services.AddTransient<IRatingRepository, RatingRepository>();
builder.Services.AddTransient<ISiteRepository, SiteRepository>(); // pg 18, add for each table?
//builder.Services.AddTransient<TestDBRepository>();

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

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Site}/{action=List}/{id?}");

app.Run();

// COMMANDS FOR NUGET DATABASE
//1. Add-Migration [Initial]
// In step 1, Initial is first pass (Migration) of data to the database (creating info for making the table), then,
// use a different name in the brackets to begin another Migration
//2. Update-Database