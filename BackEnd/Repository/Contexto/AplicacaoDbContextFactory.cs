using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Repositorio.Contexto;

//Classe necessária para funcionar o Migrations do Entity Framework Core. Sem essa classe ocorre um erro ao executar a criação das migrations.

/*

Explicação detalhada do ChatGPT:

✔ Você está usando ASP.NET Core
✔ O DbContext está sendo configurado corretamente no Program.cs
✔ O erro ocorre porque o EF Core tenta criar o DbContext no design-time, mas o seu Repositorio (onde está o AplicacaoDbContext) é um projeto separado sem Program.cs.

👉 Então o EF não consegue usar o AddDbContext da API.

Esse é o caso clássico em que precisamos criar um DbContextFactory.

✅ SOLUÇÃO CORRETA: Criar IDesignTimeDbContextFactory

Isso resolve 100% o problema e é a recomendação oficial do EF Core para projetos separados.

Crie uma classe no projeto Repositorio (mesmo namespace do contexto):

📌 AplicacaoDbContextFactory.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Repositorio.Contexto {
    public class AplicacaoDbContextFactory : IDesignTimeDbContextFactory<AplicacaoDbContext> {
        public AplicacaoDbContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<AplicacaoDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=Imobiliaria;User Id=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;"
            );

            return new AplicacaoDbContext(optionsBuilder.Options);
        }
    }
}

🎉 Pronto — agora esse erro nunca mais aparece

❗ Por que isso funciona?

Durante a execução, a API usa AddDbContext → OK

Durante o design-time(migrations), o EF procura IDesignTimeDbContextFactory

Encontra sua factory e cria o DbContext com a connection informada

*/
public class AplicacaoDbContextFactory : IDesignTimeDbContextFactory<AplicacaoDbContext> {
    public AplicacaoDbContext CreateDbContext(string[] args) {
        var optionsBuilder = new DbContextOptionsBuilder<AplicacaoDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=Imobiliaria;User Id=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True");
        return new AplicacaoDbContext(optionsBuilder.Options);
    }
}