using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POne.Financial.Infra.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Balances_BalanceId",
                schema: "fin",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Fees",
                schema: "fin",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Fine",
                schema: "fin",
                table: "Entries");

            migrationBuilder.RenameColumn(
                name: "Recurrence",
                schema: "fin",
                table: "Entries",
                newName: "Index");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                schema: "fin",
                table: "Payment",
                type: "Decimal(10,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<Guid>(
                name: "BalanceId",
                schema: "fin",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<decimal>(
                name: "Fees",
                schema: "fin",
                table: "Payment",
                type: "Decimal(10,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Fine",
                schema: "fin",
                table: "Payment",
                type: "Decimal(10,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                schema: "fin",
                table: "Entries",
                type: "Decimal(10,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                schema: "fin",
                table: "Entries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "RecurrenceId",
                schema: "fin",
                table: "Entries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                schema: "fin",
                table: "Balances",
                type: "Decimal(10,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_RecurrenceId",
                schema: "fin",
                table: "Entries",
                column: "RecurrenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Balances_BalanceId",
                schema: "fin",
                table: "Payment",
                column: "BalanceId",
                principalSchema: "fin",
                principalTable: "Balances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Balances_BalanceId",
                schema: "fin",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Entries_RecurrenceId",
                schema: "fin",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Fees",
                schema: "fin",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Fine",
                schema: "fin",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "DueDate",
                schema: "fin",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "RecurrenceId",
                schema: "fin",
                table: "Entries");

            migrationBuilder.RenameColumn(
                name: "Index",
                schema: "fin",
                table: "Entries",
                newName: "Recurrence");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                schema: "fin",
                table: "Payment",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(10,4)");

            migrationBuilder.AlterColumn<Guid>(
                name: "BalanceId",
                schema: "fin",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                schema: "fin",
                table: "Entries",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(10,4)");

            migrationBuilder.AddColumn<decimal>(
                name: "Fees",
                schema: "fin",
                table: "Entries",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Fine",
                schema: "fin",
                table: "Entries",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                schema: "fin",
                table: "Balances",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(10,4)");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Balances_BalanceId",
                schema: "fin",
                table: "Payment",
                column: "BalanceId",
                principalSchema: "fin",
                principalTable: "Balances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
