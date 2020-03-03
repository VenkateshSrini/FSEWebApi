using Microsoft.EntityFrameworkCore.Migrations;

namespace POPSAPI.Migrations
{
    public partial class UpdatedCLName_Constraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SUPLADDR",
                table: "SUPPLIER",
                type: "VARCHAR(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(15)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PoDetails_PoMasters_PONO",
                table: "PoDetails",
                column: "PONO",
                principalTable: "PoMasters",
                principalColumn: "PONO",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoDetails_PoMasters_PONO",
                table: "PoDetails");

            migrationBuilder.AlterColumn<string>(
                name: "SUPLADDR",
                table: "SUPPLIER",
                type: "VARCHAR(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(40)",
                oldNullable: true);
        }
    }
}
