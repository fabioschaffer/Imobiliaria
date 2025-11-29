using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class migration_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Imobiliaria");

            migrationBuilder.EnsureSchema(
                name: "Endereco");

            migrationBuilder.CreateTable(
                name: "Caracteristica",
                schema: "Imobiliaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracteristica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadeFederacao",
                schema: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadeFederacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                schema: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    UnidadeFederacaoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidade_UnidadeFederacao_UnidadeFederacaoId",
                        column: x => x.UnidadeFederacaoId,
                        principalSchema: "Endereco",
                        principalTable: "UnidadeFederacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                schema: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CEP = table.Column<string>(type: "TEXT", nullable: false),
                    Logradouro = table.Column<string>(type: "TEXT", nullable: false),
                    Numero = table.Column<string>(type: "TEXT", nullable: false),
                    Complemento = table.Column<string>(type: "TEXT", nullable: false),
                    CidadeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalSchema: "Endereco",
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imovel",
                schema: "Imobiliaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoImovel = table.Column<int>(type: "INTEGER", nullable: false),
                    Area = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quartos = table.Column<byte>(type: "INTEGER", nullable: false),
                    VagasGaragem = table.Column<byte>(type: "INTEGER", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    EnderecoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imovel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imovel_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalSchema: "Endereco",
                        principalTable: "Endereco",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ImovelCaracteristica",
                schema: "Imobiliaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImovelId = table.Column<int>(type: "INTEGER", nullable: false),
                    CaracteristicaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImovelCaracteristica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImovelCaracteristica_Caracteristica_CaracteristicaId",
                        column: x => x.CaracteristicaId,
                        principalSchema: "Imobiliaria",
                        principalTable: "Caracteristica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImovelCaracteristica_Imovel_ImovelId",
                        column: x => x.ImovelId,
                        principalSchema: "Imobiliaria",
                        principalTable: "Imovel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_UnidadeFederacaoId",
                schema: "Endereco",
                table: "Cidade",
                column: "UnidadeFederacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_CidadeId",
                schema: "Endereco",
                table: "Endereco",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Imovel_EnderecoId",
                schema: "Imobiliaria",
                table: "Imovel",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_ImovelCaracteristica_CaracteristicaId",
                schema: "Imobiliaria",
                table: "ImovelCaracteristica",
                column: "CaracteristicaId");

            migrationBuilder.CreateIndex(
                name: "IX_ImovelCaracteristica_ImovelId_CaracteristicaId",
                schema: "Imobiliaria",
                table: "ImovelCaracteristica",
                columns: new[] { "ImovelId", "CaracteristicaId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImovelCaracteristica",
                schema: "Imobiliaria");

            migrationBuilder.DropTable(
                name: "Caracteristica",
                schema: "Imobiliaria");

            migrationBuilder.DropTable(
                name: "Imovel",
                schema: "Imobiliaria");

            migrationBuilder.DropTable(
                name: "Endereco",
                schema: "Endereco");

            migrationBuilder.DropTable(
                name: "Cidade",
                schema: "Endereco");

            migrationBuilder.DropTable(
                name: "UnidadeFederacao",
                schema: "Endereco");
        }
    }
}
