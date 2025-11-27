using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class migration_004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imovel_Endereco_EnderecoId",
                schema: "Imobiliaria",
                table: "Imovel");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                schema: "Imobiliaria",
                table: "Imovel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Imovel_Endereco_EnderecoId",
                schema: "Imobiliaria",
                table: "Imovel",
                column: "EnderecoId",
                principalSchema: "Endereco",
                principalTable: "Endereco",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imovel_Endereco_EnderecoId",
                schema: "Imobiliaria",
                table: "Imovel");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                schema: "Imobiliaria",
                table: "Imovel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Imovel_Endereco_EnderecoId",
                schema: "Imobiliaria",
                table: "Imovel",
                column: "EnderecoId",
                principalSchema: "Endereco",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
