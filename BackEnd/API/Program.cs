using Aplicacao.Endereco.Interfaces;
using Aplicacao.Endereco.Servicos;
using Aplicacao.Imobiliaria.Interfaces;
using Aplicacao.Imobiliaria.Servicos;
using Aplicacao.Interfaces.ImovelNS;
using Aplicacao.Servicos.Imovel;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using Repositorio.Interfaces;
using Repositorio.Interfaces.ImovelNS;
using Repositorio.Repositorios;
using Repositorio.Repositorios.ImovelNS;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

ConfiguraRepositorio(builder);
ConfiguraService(builder);

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ConfiguraRepositorio(WebApplicationBuilder builder) {
    builder.Services.AddDbContext<AplicacaoDbContext>(
        options =>
        {
            var provider = builder.Configuration["Database:Provider"];
            var connection = string.Empty;
            if (provider == "SQLServer")
            {
                connection = builder.Configuration["Database:ConnectionString_SQLServer"];
                options.UseSqlServer(connection);
            }
            else if (provider == "SQLite")
            {
                connection = builder.Configuration["Database:ConnectionString_SQLite"];
                options.UseSqlite(connection);
            }
            else
                throw new Exception("Provider de banco inválido");
        });

    builder.Services.AddScoped<IUnidadeFederacaoRepository, UnidadeFederacaoRepository>();
    builder.Services.AddScoped<ICaracteristicaRepository, CaracteristicaRepository>();
    builder.Services.AddScoped<IImovelRepository, ImovelRepository>();
    builder.Services.AddScoped<ITipoRepository, TipoRepository>();
}

static void ConfiguraService(WebApplicationBuilder builder) {
    builder.Services.AddScoped<IUnidadeFederacaoService, UnidadeFederacaoService>();
    builder.Services.AddScoped<ICaracteristicaService, CaracteristicaService>();
    builder.Services.AddScoped<IImovelService, ImovelService>();
    builder.Services.AddScoped<ITipoService, TipoService>();
}