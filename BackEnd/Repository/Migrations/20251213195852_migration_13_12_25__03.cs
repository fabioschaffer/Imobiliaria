using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class migration_13_12_25__03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Orcamento_Servicos_T_Orcamento_Id",
                table: "T_Orcamento_Servicos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "T_Orcamento_Servicos",
                newName: "OrcamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Orcamento_Servicos_T_Orcamento_OrcamentoId",
                table: "T_Orcamento_Servicos",
                column: "OrcamentoId",
                principalTable: "T_Orcamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Orcamento_Servicos_T_Orcamento_OrcamentoId",
                table: "T_Orcamento_Servicos");

            migrationBuilder.RenameColumn(
                name: "OrcamentoId",
                table: "T_Orcamento_Servicos",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Orcamento_Servicos_T_Orcamento_Id",
                table: "T_Orcamento_Servicos",
                column: "Id",
                principalTable: "T_Orcamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
