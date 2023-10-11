using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Opdracht4.Migrations
{
    /// <inheritdoc />
    public partial class _0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "attractie",
                columns: table => new
                {
                    AttractieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attractie", x => x.AttractieID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medewerker",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medewerker", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "gast",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    GeboorteDatum = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EersteBezoek = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AttractieID = table.Column<int>(type: "int", nullable: false),
                    BegeleiderID = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gast", x => x.ID);
                    table.ForeignKey(
                        name: "FK_gast_attractie_AttractieID",
                        column: x => x.AttractieID,
                        principalTable: "attractie",
                        principalColumn: "AttractieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gast_gast_BegeleiderID",
                        column: x => x.BegeleiderID,
                        principalTable: "gast",
                        principalColumn: "ID");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "onderhoud",
                columns: table => new
                {
                    OnderhoudID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MedewerkerID = table.Column<int>(type: "int", nullable: false),
                    Probleem = table.Column<string>(type: "longtext", nullable: false),
                    _dtb_Begin = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    _dtb_End = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_onderhoud", x => x.OnderhoudID);
                    table.ForeignKey(
                        name: "FK_onderhoud_medewerker_MedewerkerID",
                        column: x => x.MedewerkerID,
                        principalTable: "medewerker",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "reservering",
                columns: table => new
                {
                    ReserveringID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    _dtb_Begin = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    _dtb_End = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    GastID = table.Column<int>(type: "int", nullable: false),
                    AttractieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservering", x => x.ReserveringID);
                    table.ForeignKey(
                        name: "FK_reservering_attractie_AttractieID",
                        column: x => x.AttractieID,
                        principalTable: "attractie",
                        principalColumn: "AttractieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservering_gast_GastID",
                        column: x => x.GastID,
                        principalTable: "gast",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_gast_AttractieID",
                table: "gast",
                column: "AttractieID");

            migrationBuilder.CreateIndex(
                name: "IX_gast_BegeleiderID",
                table: "gast",
                column: "BegeleiderID");

            migrationBuilder.CreateIndex(
                name: "IX_onderhoud_MedewerkerID",
                table: "onderhoud",
                column: "MedewerkerID");

            migrationBuilder.CreateIndex(
                name: "IX_reservering_AttractieID",
                table: "reservering",
                column: "AttractieID");

            migrationBuilder.CreateIndex(
                name: "IX_reservering_GastID",
                table: "reservering",
                column: "GastID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "onderhoud");

            migrationBuilder.DropTable(
                name: "reservering");

            migrationBuilder.DropTable(
                name: "medewerker");

            migrationBuilder.DropTable(
                name: "gast");

            migrationBuilder.DropTable(
                name: "attractie");
        }
    }
}
