using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POne.Financial.Infra.Migrations
{
    public partial class V8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecurrenceEnd_Month",
                schema: "fin",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "RecurrenceEnd_Year",
                schema: "fin",
                table: "Entries");

            migrationBuilder.AddColumn<DateTime>(
                name: "RecurrenceBegin",
                schema: "fin",
                table: "Entries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RecurrenceEnd",
                schema: "fin",
                table: "Entries",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecurrenceBegin",
                schema: "fin",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "RecurrenceEnd",
                schema: "fin",
                table: "Entries");

            migrationBuilder.AddColumn<int>(
                name: "RecurrenceEnd_Month",
                schema: "fin",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecurrenceEnd_Year",
                schema: "fin",
                table: "Entries",
                type: "int",
                nullable: true);
        }
    }
}
