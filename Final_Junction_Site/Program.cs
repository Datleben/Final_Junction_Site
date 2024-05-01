using Microsoft.EntityFrameworkCore;
using Final_Junction_Site.Models;
using Microsoft.AspNetCore.Identity;
using SportsStore.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

//Add when Rating Interface and Repository are created
builder.Services.AddTransient<IRatingRepository, EFRatingRepository>();
builder.Services.AddTransient<ICustomerRepository, EFCustomerRepository>();
builder.Services.AddTransient<ISiteRepository, SiteRepository>(); // pg 18, add for each table?
builder.Services.AddTransient<IUserService, UserService>();
//builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

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
app.UseAuthentication();
app.UseAuthorization();


// Don't change default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Site}/{action=List}/{id?}");

// Define custom route for ResultPage
app.MapControllerRoute(
    name: "resultpage",
    pattern: "ResultPage/{searchQuery?}",
    defaults: new { controller = "ResultPage", action = "ResultPage" }
);
app.UseSession();
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();