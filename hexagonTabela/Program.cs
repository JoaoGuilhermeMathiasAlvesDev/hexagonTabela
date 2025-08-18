using hexagonTabela.Configuracao;
using hexagonTabela.Context;
using hexagonTabela.IRepository;
using hexagonTabela.Repository;
using hexagonTabela.Serveces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HexagonContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HexagonTabela")));
builder.Services.InjeicaoDeIdependenciaConfiguracao(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
