using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POne.Financial.Infra.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                schema: "fin",
                table: "Entries",
                newName: "Operation");

            migrationBuilder.RenameColumn(
                name: "RecurrenceId",
                schema: "fin",
                table: "Entries",
                newName: "InstallmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Entries_RecurrenceId",
                schema: "fin",
                table: "Entries",
                newName: "IX_Entries_InstallmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Operation",
                schema: "fin",
                table: "Entries",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "InstallmentId",
                schema: "fin",
                table: "Entries",
                newName: "RecurrenceId");

            migrationBuilder.RenameIndex(
                name: "IX_Entries_InstallmentId",
                schema: "fin",
                table: "Entries",
                newName: "IX_Entries_RecurrenceId");
        }
    }
}
