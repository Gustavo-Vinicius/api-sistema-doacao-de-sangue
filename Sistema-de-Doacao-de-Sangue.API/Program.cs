using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Doacao_de_Sangue.API.Configuration;
using Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterDoadorPorId;
using Sistema_de_Doacao_de_Sangue.Infrastructure.Persistence;
using Microsoft.IdentityModel.Tokens;
using Sistema_de_Doacao_de_Sangue.Core.Utils;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDependencyInjection();

builder.Services.AddSwaggerConfiguration();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

});

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

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
