using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POne.Financial.Infra.Migrations
{
    public partial class V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Institution",
                schema: "fin",
                table: "Balances");

            migrationBuilder.AddColumn<Guid>(
                name: "BankId",
                schema: "fin",
                table: "Balances",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Banks",
                schema: "fin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balances_BankId",
                schema: "fin",
                table: "Balances",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_Banks_BankId",
                schema: "fin",
                table: "Balances",
                column: "BankId",
                principalSchema: "fin",
                principalTable: "Banks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_Banks_BankId",
                schema: "fin",
                table: "Balances");

            migrationBuilder.DropTable(
                name: "Banks",
                schema: "fin");

            migrationBuilder.DropIndex(
                name: "IX_Balances_BankId",
                schema: "fin",
                table: "Balances");

            migrationBuilder.DropColumn(
                name: "BankId",
                schema: "fin",
                table: "Balances");

            migrationBuilder.AddColumn<string>(
                name: "Institution",
                schema: "fin",
                table: "Balances",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }
    }
}
