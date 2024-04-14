using ManagerLayer;
// Add any other necessary 'using' directives for your repositories or services

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register ProjectManager and other dependencies here
builder.Services.AddScoped<ProjectManager>();
// If ProjectManager depends on other services or repositories, register them as well:
// builder.Services.AddScoped<IYourRepository, YourRepositoryImplementation>();
// ... add other necessary services and repositories

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
