using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestioneOrdini.RepositoryEF.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodiceCliente = table.Column<string>(maxLength: 20, nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Cognome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.Id);
                    table.UniqueConstraint("AK_Clienti_CodiceCliente", x => x.CodiceCliente);
                });

            migrationBuilder.CreateTable(
                name: "Ordini",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodiceOrdine = table.Column<string>(maxLength: 20, nullable: false),
                    CodiceProdotto = table.Column<string>(maxLength: 20, nullable: false),
                    Importo = table.Column<decimal>(type: "decimal", nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    DataOrdine = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordini", x => x.Id);
                    table.UniqueConstraint("AK_Ordini_CodiceOrdine", x => x.CodiceOrdine);
                    table.ForeignKey(
                        name: "FK_Ordini_Clienti_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordini_ClienteId",
                table: "Ordini",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordini");

            migrationBuilder.DropTable(
                name: "Clienti");
        }
    }
}
