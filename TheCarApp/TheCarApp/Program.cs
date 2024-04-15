using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);

// Register Razor Pages
builder.Services.AddRazorPages();

// Setup authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/SignUpPage"; // Dedicated login page
        options.AccessDeniedPath = "/SignUpPage"; // Separate access denied page
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.Cookie.HttpOnly = true; // Enhance security by making the cookie accessible only through the HTTP protocol
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Ensure the cookie is only sent over HTTPS
    });

// Add any necessary DI services
// builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error"); // Use a custom error handling page
    app.UseHsts(); // Enforce HTTPS
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
