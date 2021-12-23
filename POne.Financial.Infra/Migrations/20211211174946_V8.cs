using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POne.Financial.Infra.Migrations
{
    public partial class V8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BarCode",
                schema: "fin",
                table: "Entries",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Agency",
                schema: "fin",
                table: "Balances",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Institution",
                schema: "fin",
                table: "Balances",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                schema: "fin",
                table: "Balances",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarCode",
                schema: "fin",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Agency",
                schema: "fin",
                table: "Balances");

            migrationBuilder.DropColumn(
                name: "Institution",
                schema: "fin",
                table: "Balances");

            migrationBuilder.DropColumn(
                name: "Number",
                schema: "fin",
                table: "Balances");
        }
    }
}
