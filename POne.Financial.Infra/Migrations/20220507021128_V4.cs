using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POne.Financial.Infra.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency",
                schema: "fin",
                table: "Entries",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                schema: "fin",
                table: "Entries");
        }
    }
}
