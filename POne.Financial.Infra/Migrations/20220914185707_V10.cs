using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POne.Financial.Infra.Migrations
{
    public partial class V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WalletId",
                schema: "fin",
                table: "Entries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_WalletId",
                schema: "fin",
                table: "Entries",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Wallets_WalletId",
                schema: "fin",
                table: "Entries",
                column: "WalletId",
                principalSchema: "fin",
                principalTable: "Wallets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Wallets_WalletId",
                schema: "fin",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_WalletId",
                schema: "fin",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "WalletId",
                schema: "fin",
                table: "Entries");
        }
    }
}
