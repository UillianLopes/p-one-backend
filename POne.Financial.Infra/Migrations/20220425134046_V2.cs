using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POne.Financial.Infra.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Wallets_BalanceId",
                schema: "fin",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "BalanceId",
                schema: "fin",
                table: "Payment",
                newName: "WalletId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_BalanceId",
                schema: "fin",
                table: "Payment",
                newName: "IX_Payment_WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Wallets_WalletId",
                schema: "fin",
                table: "Payment",
                column: "WalletId",
                principalSchema: "fin",
                principalTable: "Wallets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Wallets_WalletId",
                schema: "fin",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "WalletId",
                schema: "fin",
                table: "Payment",
                newName: "BalanceId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_WalletId",
                schema: "fin",
                table: "Payment",
                newName: "IX_Payment_BalanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Wallets_BalanceId",
                schema: "fin",
                table: "Payment",
                column: "BalanceId",
                principalSchema: "fin",
                principalTable: "Wallets",
                principalColumn: "Id");
        }
    }
}
