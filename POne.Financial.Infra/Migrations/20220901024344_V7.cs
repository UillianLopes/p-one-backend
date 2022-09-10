using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace POne.Financial.Infra.Migrations
{
    public partial class V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recurrences",
                schema: "fin",
                table: "Entries");

            migrationBuilder.AlterColumn<int>(
                name: "Index",
                schema: "fin",
                table: "Entries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Installments",
                schema: "fin",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                schema: "fin",
                table: "Entries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Recurrence",
                schema: "fin",
                table: "Entries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecurrenceDayOfMonth",
                schema: "fin",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecurrenceDayOfWeek",
                schema: "fin",
                table: "Entries",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ParentId",
                schema: "fin",
                table: "Entries",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Entries_ParentId",
                schema: "fin",
                table: "Entries",
                column: "ParentId",
                principalSchema: "fin",
                principalTable: "Entries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Entries_ParentId",
                schema: "fin",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_ParentId",
                schema: "fin",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Installments",
                schema: "fin",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "fin",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Recurrence",
                schema: "fin",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "RecurrenceDayOfMonth",
                schema: "fin",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "RecurrenceDayOfWeek",
                schema: "fin",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "RecurrenceEnd_Month",
                schema: "fin",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "RecurrenceEnd_Year",
                schema: "fin",
                table: "Entries");

            migrationBuilder.AlterColumn<int>(
                name: "Index",
                schema: "fin",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Recurrences",
                schema: "fin",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
