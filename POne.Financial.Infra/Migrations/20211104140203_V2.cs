using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace POne.Financial.Infra.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BalanceId",
                schema: "fin",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Payment_BalanceId",
                schema: "fin",
                table: "Payment",
                column: "BalanceId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Balances_BalanceId",
                schema: "fin",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_BalanceId",
                schema: "fin",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "BalanceId",
                schema: "fin",
                table: "Payment");
        }
    }
}
