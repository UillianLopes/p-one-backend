using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POne.Financial.Infra.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "fin",
                table: "Wallets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                schema: "fin",
                table: "Wallets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "fin",
                table: "Entries",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                schema: "fin",
                table: "Entries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "fin",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                schema: "fin",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_AccountId",
                schema: "fin",
                table: "Wallets",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_AccountId",
                schema: "fin",
                table: "Entries",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AccountId",
                schema: "fin",
                table: "Categories",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Wallets_AccountId",
                schema: "fin",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Entries_AccountId",
                schema: "fin",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Categories_AccountId",
                schema: "fin",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AccountId",
                schema: "fin",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "AccountId",
                schema: "fin",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "AccountId",
                schema: "fin",
                table: "Categories");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "fin",
                table: "Wallets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "fin",
                table: "Entries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "fin",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
