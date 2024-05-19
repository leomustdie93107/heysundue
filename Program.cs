using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Heysundue.Data;
using Microsoft.Extensions.DependencyInjection;
using Heysundue.Models;
var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment;

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

// Add DbContext and ConfigureServices
builder.Services.AddDbContext<ArticleContext>(options =>
{
    if (env.IsDevelopment())
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("ArticleContext"));
    }
    else
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("ArticleContext"));
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!env.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
