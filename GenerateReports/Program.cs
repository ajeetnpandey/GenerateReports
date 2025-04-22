using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using GenerateReports.Models;
using GenerateReports.Data;
using GenerateReportss;

var builder = WebApplication.CreateBuilder(args);

// ------------------ Services Registration ------------------ //

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controllers
builder.Services.AddControllers();

// Custom services
builder.Services.AddCustomServices();

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GenerateFileinMultipleformet API",
        Version = "v1"
    });
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:7044") // Adjust as needed
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// ------------------ Middleware Configuration ------------------ //

// Auto migration
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();  // Automatically apply migrations
}

// CORS
app.UseCors();

// Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GenerateFileinMultipleformet API v1");
});

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// Controllers
app.MapControllers();

app.Run();
