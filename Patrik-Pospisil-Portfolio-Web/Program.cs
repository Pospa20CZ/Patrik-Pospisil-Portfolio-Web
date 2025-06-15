using Microsoft.EntityFrameworkCore;
using Patrik_Pospisil_Portfolio_Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Pøidání Razor Pages a DbContext pro SQLite
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
