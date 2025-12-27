using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfraEstrutura;

public static class DependencyInjection {
    public static IServiceCollection AddLoggingInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        // 1. Obtemos a Connection String do log4net (ou definimos uma padrão)
        // É recomendável que esta string seja a mesma usada no log4net.config
        var connectionString = "Data Source=logs_api.db;";

        // 2. Extraímos o nome do arquivo para garantir que o diretório exista
        // (Útil se você usar caminhos como "Logs/api.db")
        var builder = new SqliteConnectionStringBuilder(connectionString);
        var filePath = builder.DataSource;

        if (!string.IsNullOrEmpty(Path.GetDirectoryName(filePath))) {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }

        // 3. Executamos o script de criação da tabela
        try {
            using (var connection = new SqliteConnection(connectionString)) {
                connection.Open();

                var tableCommand = @"
                        CREATE TABLE IF NOT EXISTS Log (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Date DATETIME NOT NULL,
                            Thread TEXT NOT NULL,
                            Level TEXT NOT NULL,
                            Logger TEXT NOT NULL,
                            Message TEXT NOT NULL,
                            Exception TEXT NULL
                        );";

                using (var command = new SqliteCommand(tableCommand, connection)) {
                    command.ExecuteNonQuery();
                }
            }
        } catch (SqliteException ex) {
            // Aqui você pode decidir se interrompe a aplicação ou apenas loga no console
            System.Console.WriteLine($"Erro ao inicializar banco de logs SQLite: {ex.Message}");
        }

        return services;
    }
}