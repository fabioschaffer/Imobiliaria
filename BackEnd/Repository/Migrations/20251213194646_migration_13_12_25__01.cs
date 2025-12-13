using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class migration_13_12_25__01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Orcamento_Servicos",
                columns: table => new
                {
                    OrcamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    preco_hora_pintura = table.Column<int>(type: "INTEGER", nullable: false),
                    quantidade_horas_pintura = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Orcamento_Servicos", x => x.OrcamentoId);
                });

            migrationBuilder.CreateTable(
                name: "T_Orcamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    Versao = table.Column<int>(type: "INTEGER", nullable: false),
                    ServicosOrcamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Orcamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Orcamento_T_Orcamento_Servicos_ServicosOrcamentoId",
                        column: x => x.ServicosOrcamentoId,
                        principalTable: "T_Orcamento_Servicos",
                        principalColumn: "OrcamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Orcamento_ServicosOrcamentoId",
                table: "T_Orcamento",
                column: "ServicosOrcamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Orcamento");

            migrationBuilder.DropTable(
                name: "T_Orcamento_Servicos");
        }
    }
}
