using AlbertoWebApi.Application.Applications;
using AlbertoWebApi.Application.Interfaces;
using AlbertoWebApi.Data;
using AlbertoWebApi.Infra.Interfaces;
using AlbertoWebApi.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPessoaApplication, PessoaAplication>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

//Adicionando o contexto na aplicação -- 00


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); // Conection Strig utilizada - 03

// informando o banco de dados que eu usarei -01

builder.Services.AddDbContext<AlbertoWebApiContext>(options => {

    //ConexionString - 02

    options.UseSqlServer(connectionString);


    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
