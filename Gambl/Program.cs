
using Gambl.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Admission"; 
        options.LogoutPath = "/Login/Logout";
    });

builder.Services.AddDbContext<DataContext>(options=>{
    var connectionString = builder.Configuration.GetConnectionString("database");
    options.UseSqlite(connectionString);
});

var app = builder.Build();

app.UseStaticFiles(); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
