using Microsoft.EntityFrameworkCore;
using UdemyClone.Application.Interfaces;
using UdemyClone.Application.Services;
using UdemyClone.Domain.Database;
using UdemyClone.Domain.Interfaces;
using UdemyClone.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UdemyCloneContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEstudianteService, EstudianteService>();
builder.Services.AddScoped<IEstudianteRepository, EstudianteRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "UdemyClone API");
    });
}

app.UseAuthorization();
app.MapControllers();
app.Run();