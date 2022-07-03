using MuscleGroups.API.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MuscleGroups.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MuscleGroup.API", Version = "v1" });
});

var connectionString = builder.Configuration.GetConnectionString("MuscleGroupConnectionString");
builder.Services.AddDbContext<MuscleGroupContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddScoped<IMuscleGroupRepository, MuscleGroupRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MuscleGroup.API v1"));
}

app.UseAuthorization();

app.MapControllers();

app.Run();
