using Microsoft.EntityFrameworkCore;
using Sistema_de_Doacao_de_Sangue.API.Configuration;
using Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterDoadorPorId;
using Sistema_de_Doacao_de_Sangue.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfiguration();

builder.Services.AddSwaggerGen();

builder.Services.AddDependencyInjection();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ObterDoadorPorIdQuery).Assembly));

var connectionString = builder.Configuration.GetConnectionString("SistemaDoacaoDeSangue");

builder.Services.AddDbContext<AppDbContext>(p => p.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
