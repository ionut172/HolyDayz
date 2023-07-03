using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacante.DataAccess;
using Vacante.DataAccess.Repository;
using Vacante.DataAccess.Repository.IRepository;
using VacanteAPP.Models;
using VacanteAPP;
using Vacante.DataAccess.Data;
using System.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vacante.Utility;
using Stripe;
using Vacante.DataAccess.DbInitializer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ILastMinuteRepository, LastMinuteRepository>();
builder.Services.AddScoped<IVacanteStandardRepository, Vacante.DataAccess.Repository.VacanteStandard>();
builder.Services.AddScoped<ICountriesRepository, Vacante.DataAccess.Repository.Countries>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<Vacante.DataAccess.Data.ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders().AddDefaultUI();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});
builder.Services.AddAuthentication().AddFacebook(option =>
{
    option.AppId = "6048881391884995";
    option.AppSecret = "a4e23fc4f3e498391205678188caa127";
});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddScoped<IDBInitilizer, DBInitializer>();
builder.Services.AddRazorPages();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
; app.UseRouting();

app.UseAuthorization();
app.UseSession();
SeedDatabaes();
app.MapRazorPages();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Customer",
    pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}",
    defaults: new { area = "Customer" });
app.MapControllerRoute(
    name: "Products",
    pattern: "/{area:exists}/{controller=Category}/{action=Index}/{id?}");


app.Run();
void SeedDatabaes()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDBInitilizer>();
        dbInitializer.Initialize();
    }
}
