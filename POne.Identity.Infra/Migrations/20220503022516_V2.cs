using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace POne.Identity.Infra.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Settings_Configuration",
                schema: "auth",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3de581c4-3f1a-4ac3-a395-24a697eda880"),
                columns: new[] { "Creation", "LastUpdate" },
                values: new object[] { new DateTime(2022, 5, 2, 23, 25, 16, 713, DateTimeKind.Local).AddTicks(6229), new DateTime(2022, 5, 2, 23, 25, 16, 713, DateTimeKind.Local).AddTicks(6236) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Settings_Configuration",
                schema: "auth",
                table: "Users");

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3de581c4-3f1a-4ac3-a395-24a697eda880"),
                columns: new[] { "Creation", "LastUpdate" },
                values: new object[] { new DateTime(2022, 3, 21, 2, 36, 0, 437, DateTimeKind.Local).AddTicks(1670), new DateTime(2022, 3, 21, 2, 36, 0, 437, DateTimeKind.Local).AddTicks(1681) });
        }
    }
}
