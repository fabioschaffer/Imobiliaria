//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;

//namespace Repositorio.Contexto;

//public class AplicacaoDbContextFactory : IDesignTimeDbContextFactory<AplicacaoDbContext> {
//    public AplicacaoDbContext CreateDbContext(string[] args) {
//        var optionsBuilder = new DbContextOptionsBuilder<AplicacaoDbContext>();
//        optionsBuilder.UseSqlServer("Server=localhost;Database=Imobiliaria;User Id=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True");
//        return new AplicacaoDbContext(optionsBuilder.Options);
//    }
//}

//Classe necessária para funcionar o Migrations do Entity Framework Core. Sem essa classe ocorre um erro ao executar a criação das migrations.

// É outra forma de funcionar a criação das migrations. Ao implementar essa factory, o Entity Framework Core usa essa factory para criar o DbContext em tempo de design (design-time), quando você está executando comandos como "Add-Migration" ou "Update-Database" no Package Manager Console ou CLI do .NET.
// Dessa forma, é possível executar a criação das migrations diretamente no projeto Repositorio. Não é necessário referenciar o Microsoft.EntityFrameworkCore.Design no projeto API.
// O contra é que é necessário manter a connection string hardcoded nessa factory.

/*

Explicação do ChatGPT:

✔ Você está usando ASP.NET Core
✔ O DbContext está sendo configurado corretamente no Program.cs
✔ O erro ocorre porque o EF Core tenta criar o DbContext no design-time, mas o seu Repositorio (onde está o AplicacaoDbContext) é um projeto separado sem Program.cs.
👉 Então o EF não consegue usar o AddDbContext da API.

Esse é o caso clássico em que precisamos criar um DbContextFactory.

✅ SOLUÇÃO CORRETA: Criar IDesignTimeDbContextFactory
Isso resolve 100% o problema e é a recomendação oficial do EF Core para projetos separados.

❗ Por que isso funciona?
Durante a execução, a API usa AddDbContext → OK
Durante o design-time(migrations), o EF procura IDesignTimeDbContextFactory
Encontra sua factory e cria o DbContext com a connection informada

*/