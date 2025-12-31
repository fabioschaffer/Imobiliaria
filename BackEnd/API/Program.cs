using API.InjecaoDependencia;
using Aplicacao.DTOs.Ibge;
using Aplicacao.Endereco.Interfaces;
using Aplicacao.Endereco.Servicos;
using Aplicacao.Imobiliaria.Interfaces;
using Aplicacao.Imobiliaria.Servicos;
using Aplicacao.Interfaces;
using Aplicacao.Interfaces.ImovelNS;
using Aplicacao.Interfaces.T_Orcamento;
using Aplicacao.Servicos;
using Aplicacao.Servicos.Imovel;
using Aplicacao.Servicos.T_Orcamento;
using InfraEstrutura;
using InfraEstrutura.Identity;
using InfraEstrutura.Seguranca;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using Repositorio.Interfaces;
using Repositorio.Interfaces.ImovelNS;
using Repositorio.Repositorios;
using Repositorio.Repositorios.ImovelNS;
using RestEase;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

ConfiguraRepositorio(builder);
ConfiguraService(builder);
ConfiguraRestEaseIbge(builder);
builder.Services.AddInfrastructure(builder.Configuration);

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

// Adiciona os serviços de Logging.
builder.Logging.ClearProviders();

// Para ver os logs no terminal.
builder.Logging.AddConsole();

// Configuração Log no Event-Viewer do Windows.
builder.Logging.AddEventLog(settings => {
    settings.SourceName = "ImobiliariaApp"; // Nome que aparecerá na coluna 'Origem'
    settings.LogName = "Application";         // Log onde será gravado (Application é o padrão)
});

//Configuração do Log4Net.
builder.Logging.AddLog4Net("log4net.config");
builder.Services.AddLoggingInfrastructure(builder.Configuration);

//Configuração do SeriLog.
builder.Services.AddSeriLogInfrastructure(builder.Configuration);
builder.Services.AddLogging(loggingBuilder => {loggingBuilder.AddSerilog(dispose: true);});

//Configuração da Autenticação.
builder.Services.AddAuthenticationDI(builder.Configuration);

var app = builder.Build();

app.UseCors("AllowAll");

//Configuração do Middleware de autenticação e autorização.
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

static void ConfiguraRepositorio(WebApplicationBuilder builder) {
    builder.Services.AddDbContext<AplicacaoDbContext>(
        options => {
            var provider = builder.Configuration["Database:Provider"];
            var connection = string.Empty;
            if (provider == "SQLServer") {
                connection = builder.Configuration["Database:ConnectionString_SQLServer"];
                options.UseSqlServer(connection);
            } else if (provider == "SQLite") {
                connection = builder.Configuration["Database:ConnectionString_SQLite"];
                options.UseSqlite(connection);
            } else
                throw new Exception("Provider de banco inv�lido");
        });

    builder.Services.AddScoped<IUnidadeFederacaoRepository, UnidadeFederacaoRepository>();
    builder.Services.AddScoped<ICaracteristicaRepository, CaracteristicaRepository>();
    builder.Services.AddScoped<IImovelRepository, ImovelRepository>();
    builder.Services.AddScoped<ITipoRepository, TipoRepository>();
    builder.Services.AddScoped<IOrcamentoRepository, OrcamentoRepository>();
    builder.Services.AddScoped<IPesquisaImovelRepository, PesquisaImovelRepository>();
    builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
}

static void ConfiguraService(WebApplicationBuilder builder) {
    builder.Services.AddScoped<IUnidadeFederacaoService, UnidadeFederacaoService>();
    builder.Services.AddScoped<ICaracteristicaService, CaracteristicaService>();
    builder.Services.AddScoped<IImovelService, ImovelService>();
    builder.Services.AddScoped<ITipoService, TipoService>();
    builder.Services.AddScoped<IOrcamentoService, T_OrcamentoService>();
    builder.Services.AddScoped<IPesquisaImovelService, PesquisaImovelService>();
    builder.Services.AddScoped<ITokenService, TokenService>();
    builder.Services.AddScoped<IAtenticacaoService, AtenticacaoService>();
    builder.Services.AddScoped<IIdentityService, IdentityService>(); 
}

static void ConfiguraRestEaseIbge(WebApplicationBuilder builder) {
    builder.Services.AddHttpClient("IbgeClient", client => {
        client.BaseAddress = new Uri("https://servicodados.ibge.gov.br/api/v1/");
    });

    builder.Services.AddScoped<IIbgeApi>(sp => {
        var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient("IbgeClient");
        return RestClient.For<IIbgeApi>(httpClient);
    });
}