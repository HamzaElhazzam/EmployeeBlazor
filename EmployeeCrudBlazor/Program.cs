using BlazorBootstrap;
using EmployeeCrudBlazor.Context;
using EmployeeCrudBlazor.Data;
using EmployeeCrudBlazor.Data.Repositories;
using EmployeeCrudBlazor.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped<SQLEmployeeRepository>();
builder.Services.AddScoped<SQLArticleRepository>();
builder.Services.AddScoped<SQLBonCommandeRepository>();
builder.Services.AddScoped<SignInManager<ApplicationUser>>();
builder.Services.AddScoped<UserManager<ApplicationUser>>();
builder.Services.AddBlazorBootstrap();


//Connection To the DataBase
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeCrudBlazorConnection")), ServiceLifetime.Scoped);

//add indentity to project

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDbContext>();

//password Complexity
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
