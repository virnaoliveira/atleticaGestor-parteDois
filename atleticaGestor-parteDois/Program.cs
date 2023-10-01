using atleticaGestor_parteDois.Data;
using atleticaGestor_parteDois.Services.Implementation;
using atleticaGestor_parteDois.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Context>(options => options.UseNpgsql("Host=database-1.cqgole4d5zz1.us-east-1.rds.amazonaws.com;Port=5432;Database=postgres;Username=postgres;Password=admin123;"));

builder.Services.AddScoped<ITimeService, TimeServiceImplementation>();

builder.Services.AddScoped<IAMService, AMServiceImplementation>();

builder.Services.AddScoped<IAtletaService, AtletaServiceImplementation>();

builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(opcoes => opcoes.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();