using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Doacao_de_Sangue.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doadors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    TipoSanguineo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatorRh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doadors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstoqueSangues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoSanguineo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatorRh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantidadeML = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstoqueSangues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doacaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoadorId = table.Column<int>(type: "int", nullable: false),
                    DataDoacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantidadeML = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doacaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doacaos_Doadors_DoadorId",
                        column: x => x.DoadorId,
                        principalTable: "Doadors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Doadors_DoadorId",
                        column: x => x.DoadorId,
                        principalTable: "Doadors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doacaos_DoadorId",
                table: "Doacaos",
                column: "DoadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Doadors_Email",
                table: "Doadors",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_DoadorId",
                table: "Enderecos",
                column: "DoadorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doacaos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "EstoqueSangues");

            migrationBuilder.DropTable(
                name: "Doadors");
        }
    }
}
