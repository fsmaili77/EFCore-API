using efCoreApi;
using efCoreApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Configuration.AddJsonFile("appsettings.json"); // Load the configuration from appsettings.json

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Create a scope to get an instance of your DbContext
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var dbContext = services.GetRequiredService<AppDbContext>();

        // Seed the database using your SeedData.Initialize method
        SeedData.Initialize(dbContext);
    }
    catch (Exception ex)
    {
        // Handle any exceptions that occur during seeding, if necessary
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Configure the HTTP request pipeline.
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapControllers();

app.Run();
