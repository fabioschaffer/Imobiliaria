using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class migration_13_12_25__02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Orcamento_T_Orcamento_Servicos_ServicosOrcamentoId",
                table: "T_Orcamento");

            migrationBuilder.DropIndex(
                name: "IX_T_Orcamento_ServicosOrcamentoId",
                table: "T_Orcamento");

            migrationBuilder.DropColumn(
                name: "ServicosOrcamentoId",
                table: "T_Orcamento");

            migrationBuilder.RenameColumn(
                name: "OrcamentoId",
                table: "T_Orcamento_Servicos",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "T_Orcamento_Servicos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_T_Orcamento_Servicos_T_Orcamento_Id",
                table: "T_Orcamento_Servicos",
                column: "Id",
                principalTable: "T_Orcamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Orcamento_Servicos_T_Orcamento_Id",
                table: "T_Orcamento_Servicos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "T_Orcamento_Servicos",
                newName: "OrcamentoId");

            migrationBuilder.AlterColumn<int>(
                name: "OrcamentoId",
                table: "T_Orcamento_Servicos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "ServicosOrcamentoId",
                table: "T_Orcamento",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_T_Orcamento_ServicosOrcamentoId",
                table: "T_Orcamento",
                column: "ServicosOrcamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Orcamento_T_Orcamento_Servicos_ServicosOrcamentoId",
                table: "T_Orcamento",
                column: "ServicosOrcamentoId",
                principalTable: "T_Orcamento_Servicos",
                principalColumn: "OrcamentoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
