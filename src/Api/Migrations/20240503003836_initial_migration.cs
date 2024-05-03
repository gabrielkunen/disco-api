using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cantor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cantor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "label",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Regiao = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_label", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "disco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCatalogo = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Titulo = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    PrecoLancamento = table.Column<int>(type: "INT", nullable: false),
                    TipoMedia = table.Column<int>(type: "INT", nullable: false),
                    IdLabel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_disco_label_IdLabel",
                        column: x => x.IdLabel,
                        principalTable: "label",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "barcode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    IdDisco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_barcode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_barcode_disco_IdDisco",
                        column: x => x.IdDisco,
                        principalTable: "disco",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "musica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    IdDisco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_musica_disco_IdDisco",
                        column: x => x.IdDisco,
                        principalTable: "disco",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "cantormusica",
                columns: table => new
                {
                    CantoresId = table.Column<int>(type: "int", nullable: false),
                    MusicasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cantormusica", x => new { x.CantoresId, x.MusicasId });
                    table.ForeignKey(
                        name: "FK_cantormusica_cantor_CantoresId",
                        column: x => x.CantoresId,
                        principalTable: "cantor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_cantormusica_musica_MusicasId",
                        column: x => x.MusicasId,
                        principalTable: "musica",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_barcode_IdDisco",
                table: "barcode",
                column: "IdDisco",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cantormusica_MusicasId",
                table: "cantormusica",
                column: "MusicasId");

            migrationBuilder.CreateIndex(
                name: "IX_disco_IdLabel",
                table: "disco",
                column: "IdLabel");

            migrationBuilder.CreateIndex(
                name: "IX_musica_IdDisco",
                table: "musica",
                column: "IdDisco");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "barcode");

            migrationBuilder.DropTable(
                name: "cantormusica");

            migrationBuilder.DropTable(
                name: "cantor");

            migrationBuilder.DropTable(
                name: "musica");

            migrationBuilder.DropTable(
                name: "disco");

            migrationBuilder.DropTable(
                name: "label");
        }
    }
}
