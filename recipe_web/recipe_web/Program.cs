using db_helpers;
using manager_classes;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddScoped<IDBUserHelper, DBUserHelper>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IRecipeManager, RecipeManager>();
builder.Services.AddScoped<IDBRecipeHelper, DBRecipeHelper>();
builder.Services.AddScoped<IToDoListManager, ToDoListManager>();
builder.Services.AddScoped<IDBToDoListHelper, DBToDoListHelper>();
builder.Services.AddScoped<IReviewManager, ReviewManager>();
builder.Services.AddScoped<IDBReviewHelper, DBReviewHelper>();
builder.Services.AddScoped<IIngredientManager, IngredientManager>();
builder.Services.AddScoped<IDBIngredientHelper, DBIngredientHelper>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Login");
        options.LogoutPath = new PathString("/Logout");
        options.AccessDeniedPath = new PathString("/AccessDenied");
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        options.SlidingExpiration = true;
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.Run();