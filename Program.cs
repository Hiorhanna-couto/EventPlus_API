using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using EventPlus_.Interfaces;
using EventPlus_.Repositories;
using EventPlus_.Context;

var builder = WebApplication.CreateBuilder(args);

// Configuração de serviços
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// Configuração do banco de dados
builder.Services.AddDbContext<Eventos_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injeção de dependência dos repositórios
builder.Services.AddScoped<ITipoEventoRepository, TipoEventoRepository>();
builder.Services.AddScoped<ITipoUsuarioRepository, TiposUsuariosRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IPresencaEventoRepository, PresencaEventoRepository>();
builder.Services.AddScoped<IComentarioEventoRepository, ComentarioEventoRepository>();
;


//Adiciona o serviço de Controllers
builder.Services.AddControllers();


var app = builder.Build();

app.MapControllers();
