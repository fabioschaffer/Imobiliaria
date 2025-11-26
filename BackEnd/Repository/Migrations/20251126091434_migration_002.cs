using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class migration_002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Endereco");

            migrationBuilder.EnsureSchema(
                name: "Imobiliaria");

            migrationBuilder.RenameTable(
                name: "UnidadeFederacao",
                newName: "UnidadeFederacao",
                newSchema: "Endereco");

            migrationBuilder.RenameTable(
                name: "ImovelCaracteristica",
                newName: "ImovelCaracteristica",
                newSchema: "Imobiliaria");

            migrationBuilder.RenameTable(
                name: "Imovel",
                newName: "Imovel",
                newSchema: "Imobiliaria");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "Endereco",
                newSchema: "Endereco");

            migrationBuilder.RenameTable(
                name: "Cidade",
                newName: "Cidade",
                newSchema: "Endereco");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "UnidadeFederacao",
                schema: "Endereco",
                newName: "UnidadeFederacao");

            migrationBuilder.RenameTable(
                name: "ImovelCaracteristica",
                schema: "Imobiliaria",
                newName: "ImovelCaracteristica");

            migrationBuilder.RenameTable(
                name: "Imovel",
                schema: "Imobiliaria",
                newName: "Imovel");

            migrationBuilder.RenameTable(
                name: "Endereco",
                schema: "Endereco",
                newName: "Endereco");

            migrationBuilder.RenameTable(
                name: "Cidade",
                schema: "Endereco",
                newName: "Cidade");
        }
    }
}
