using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POne.Financial.Infra.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SubCategories_AccountId",
                schema: "fin",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "AccountId",
                schema: "fin",
                table: "SubCategories");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "fin",
                table: "SubCategories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategories_UserId",
                schema: "fin",
                table: "SubCategories",
                newName: "IX_SubCategories_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "fin",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                schema: "fin",
                table: "SubCategories",
                column: "CategoryId",
                principalSchema: "fin",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                schema: "fin",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "fin",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                schema: "fin",
                table: "SubCategories",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategories_CategoryId",
                schema: "fin",
                table: "SubCategories",
                newName: "IX_SubCategories_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                schema: "fin",
                table: "SubCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_AccountId",
                schema: "fin",
                table: "SubCategories",
                column: "AccountId");
        }
    }
}
