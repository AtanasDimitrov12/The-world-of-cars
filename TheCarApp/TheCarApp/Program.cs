using InterfaceLayer;
using ManagerLayer;
using ManagerLayer.Strategy;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddScoped<ProjectManager, ProjectManager>();
builder.Services.AddTransient<StandardRentalStrategy>();
builder.Services.AddTransient<PeakSeasonRentalStrategy>();
builder.Services.AddSingleton<IRentalStrategyFactory, RentalStrategyFactory>();

builder.Services.AddRazorPages();
builder.Services.AddLogging(); // Add logging services

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.LoginPath = "/SignUpPage";
        options.AccessDeniedPath = "/SignUpPage";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });

var app = builder.Build();

// Configure the HTTP request pipeline
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
