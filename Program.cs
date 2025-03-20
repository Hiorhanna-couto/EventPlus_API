using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using EventPlus_.Interfaces;
using EventPlus_.Repositories;
using EventPlus_.Context;

var builder = WebApplication.CreateBuilder(args);

// Configura��o de servi�os
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// Configura��o do banco de dados
builder.Services.AddDbContext<Eventos_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inje��o de depend�ncia dos reposit�rios
builder.Services.AddScoped<ITipoEventoRepository, TipoEventoRepository>();
builder.Services.AddScoped<ITipoUsuarioRepository, TiposUsuariosRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IPresencaEventoRepository, PresencaEventoRepository>();
builder.Services.AddScoped<IComentarioEventoRepository, ComentarioEventoRepository>();
;


//Adiciona o servi�o de Controllers
builder.Services.AddControllers();


var app = builder.Build();

app.MapControllers();
