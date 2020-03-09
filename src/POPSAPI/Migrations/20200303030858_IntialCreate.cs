using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace POPSAPI.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ITCODE = table.Column<string>(type: "CHAR(4)", nullable: false),
                    ITDESC = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    ITRATE = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Itm_Primary_key", x => x.ITCODE);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIER",
                columns: table => new
                {
                    SUPLNO = table.Column<string>(type: "CHAR(4)", nullable: false),
                    SUPLNAME = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    SUPLADDR = table.Column<string>(type: "VARCHAR(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("suppl_primary_key", x => x.SUPLNO);
                });

            migrationBuilder.CreateTable(
                name: "PoMasters",
                columns: table => new
                {
                    PONO = table.Column<string>(type: "CHAR(4)", nullable: false),
                    PODATE = table.Column<DateTime>(type: "timestamp", nullable: false),
                    SUPLNO = table.Column<string>(type: "CHAR(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pom_primary_key", x => x.PONO);
                    table.ForeignKey(
                        name: "FK_PoMasters_SUPPLIER_SUPLNO",
                        column: x => x.SUPLNO,
                        principalTable: "SUPPLIER",
                        principalColumn: "SUPLNO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoDetails",
                columns: table => new
                {
                    PONO = table.Column<string>(type: "Char(4)", nullable: false),
                    ITCODE = table.Column<string>(type: "CHAR(4)", nullable: false),
                    QTY = table.Column<int>(type: "integer", nullable: false),
                    PurchaseOrderMasterPoNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pod_primary_key", x => new { x.PONO, x.ITCODE });
                    table.ForeignKey(
                        name: "FK_PoDetails_Items_ITCODE",
                        column: x => x.ITCODE,
                        principalTable: "Items",
                        principalColumn: "ITCODE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoDetails_PoMasters_PurchaseOrderMasterPoNumber",
                        column: x => x.PurchaseOrderMasterPoNumber,
                        principalTable: "PoMasters",
                        principalColumn: "PONO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoDetails_ITCODE",
                table: "PoDetails",
                column: "ITCODE");

            migrationBuilder.CreateIndex(
                name: "IX_PoDetails_PurchaseOrderMasterPoNumber",
                table: "PoDetails",
                column: "PurchaseOrderMasterPoNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PoMasters_SUPLNO",
                table: "PoMasters",
                column: "SUPLNO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoDetails");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "PoMasters");

            migrationBuilder.DropTable(
                name: "SUPPLIER");
        }
    }
}
