using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class migration_003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Caracteristica",
                newName: "Caracteristica",
                newSchema: "Imobiliaria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Caracteristica",
                schema: "Imobiliaria",
                newName: "Caracteristica");
        }
    }
}
