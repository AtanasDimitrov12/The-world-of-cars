using InterfaceLayer;
using ManagerLayer.Strategy;
using ManagerLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore; // For DbContext if you're using a database
using Data; // Assuming your DbContext is in this namespace

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext (if using Entity Framework Core)
builder.Services.AddDbContext<CarAppContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(@"Server=DESKTOP-IL35000\SQLEXPRESS;Database=CarApp;Integrated Security=true;TrustServerCertificate=True"));
});

// Register your ProjectManager and other dependencies
builder.Services.AddScoped<ProjectManager, ProjectManager>();
builder.Services.AddTransient<StandardRentalStrategy>();
builder.Services.AddTransient<PeakSeasonRentalStrategy>();
builder.Services.AddSingleton<IRentalStrategyFactory, RentalStrategyFactory>();

// Add AutoMapper (if you need it)
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add Razor Pages and MVC Controllers
builder.Services.AddRazorPages();
builder.Services.AddControllers();

// Configure Cookie Authentication
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

// Configure CORS if needed
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Use CORS if necessary
app.UseCors("AllowAllOrigins");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Use Authentication and Authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
