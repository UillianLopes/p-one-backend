using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POne.Financial.Infra.Migrations
{
    public partial class V11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                schema: "fin",
                table: "Categories",
                newName: "Operation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Operation",
                schema: "fin",
                table: "Categories",
                newName: "Type");
        }
    }
}
