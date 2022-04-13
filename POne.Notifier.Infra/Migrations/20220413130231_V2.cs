using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POne.Notifier.Infra.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                schema: "fin",
                table: "Notifications");

            migrationBuilder.EnsureSchema(
                name: "ntf");

            migrationBuilder.RenameTable(
                name: "Notifications",
                schema: "fin",
                newName: "Notifications",
                newSchema: "ntf");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "ntf",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "NotificationStates",
                schema: "ntf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationStates_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalSchema: "ntf",
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationStates_NotificationId",
                schema: "ntf",
                table: "NotificationStates",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationStates_UserId",
                schema: "ntf",
                table: "NotificationStates",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationStates",
                schema: "ntf");

            migrationBuilder.EnsureSchema(
                name: "fin");

            migrationBuilder.RenameTable(
                name: "Notifications",
                schema: "ntf",
                newName: "Notifications",
                newSchema: "fin");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "fin",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                schema: "fin",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
