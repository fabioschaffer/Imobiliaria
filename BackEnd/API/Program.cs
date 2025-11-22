using Aplicacao.Interfaces;
using Aplicacao.Servicos;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using Repositorio.Interfaces;
using Repositorio.Repositorios;

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
        options => options.UseSqlServer(builder.Configuration["ConnectionStrings:Imobiliaria"])
    );

    builder.Services.AddScoped<IUnidadeFederacaoRepository, UnidadeFederacaoRepository>();
}

static void ConfiguraService(WebApplicationBuilder builder) {
    builder.Services.AddScoped<IUnidadeFederacaoService, UnidadeFederacaoService>();
}