using DAOs;
using manager_classes;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IUserDAO, UserDAO>();
builder.Services.AddScoped<UserManager>();

// Adding authentication services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login"; // Your Login page path
        options.LogoutPath = "/Logout"; // Your Logout page path
        options.AccessDeniedPath = "/AccessDenied"; // Path when access is denied
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // This must be called before UseAuthorization
app.UseAuthorization();

app.MapRazorPages();

app.Run();
