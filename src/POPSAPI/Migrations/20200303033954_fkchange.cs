using Microsoft.EntityFrameworkCore.Migrations;

namespace POPSAPI.Migrations
{
    public partial class fkchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_PoDetails_PoMasters_PurchaseOrderMasterPoNumber", "PoDetails");
            migrationBuilder.DropColumn("PurchaseOrderMasterPoNumber", "PoDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>("PurchaseOrderMasterPoNumber", "PoDetails", "CHAR(4)");
            migrationBuilder.AddForeignKey(
                name: "FK_PoDetails_PoMasters_PurchaseOrderMasterPoNumber",
                table: "PoDetails",
                column: "PurchaseOrderMasterPoNumber",
                principalTable: "PoMasters",
                principalColumn: "PONO",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
