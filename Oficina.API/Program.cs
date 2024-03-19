using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OficinaOS.Domain.Interfaces.Repositories;
using OficinaOS.Infrastructure.Context;
using OficinaOS.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "OficinaOS.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Alef David",
            Url = new Uri("https://www.linkedin.com/in/alefdavid/")          
        }
    });
});

//Context
var connectionString = builder.Configuration.GetConnectionString("BDAccompanyCar");
builder.Services.AddDbContext<OficinaDbContext>(options => options.UseSqlServer(connectionString));

//DependencyInjection
builder.Services.AddTransient<IPessoaRepository, PessoaRepository>();
builder.Services.AddTransient<IPecaRepository, PecaRepository>();


builder.Services.AddControllers();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


