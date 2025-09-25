using Microsoft.EntityFrameworkCore;
using PF_LAB3.Data;
using Microsoft.AspNetCore.Identity; // Kailangan para sa AddDefaultIdentity
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore; // Kailangan para sa UseMigrationsEndPoint

var builder = WebApplication.CreateBuilder(args);

// 1. Tanging ApplicationDbContext (Identity) lang ang ire-rehistro
// Tandaan: Ang GreedDbContext registration ay TANGGALIN muna para maiwasan ang database error.
var defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(defaultConnection));

// 2. Configure Identity
// Ang AddDefaultIdentity ay dapat makita na ngayon dahil sa 'using Microsoft.AspNetCore.Identity;'
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add controllers with views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // UseMigrationsEndPoint ay dapat makita na ngayon
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    // Ang default ay naka-set sa Home/Index
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map identity razor pages
app.MapRazorPages();

app.Run();