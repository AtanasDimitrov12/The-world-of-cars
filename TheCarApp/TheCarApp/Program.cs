using InterfaceLayer;
using ManagerLayer.Strategy;
using ManagerLayer;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ProjectManager, ProjectManager>();
builder.Services.AddTransient<StandardRentalStrategy>();
builder.Services.AddTransient<PeakSeasonRentalStrategy>();
builder.Services.AddSingleton<IRentalStrategyFactory, RentalStrategyFactory>();

builder.Services.AddRazorPages();
builder.Services.AddLogging(); 

builder.Services.AddControllers();

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
app.MapControllers();

app.Run();
