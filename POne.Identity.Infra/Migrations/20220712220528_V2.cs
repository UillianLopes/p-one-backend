using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POne.Identity.Infra.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "auth",
                table: "Profiles",
                columns: new[] { "Id", "AccountId", "Creation", "Description", "IsDefault", "IsDeleted", "LastUpdate", "Name" },
                values: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), new Guid("ce4b628f-3561-49e8-9560-5e16ef46dfe9"), new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "POne Admin profile", true, false, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "POne Admin" });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "ProfileRoles",
                columns: new[] { "ProfilesId", "RolesKey" },
                values: new object[,]
                {
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "ADMIN_PROFILE_CREATE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "ADMIN_PROFILE_DELETE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "ADMIN_PROFILE_READ" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "ADMIN_PROFILE_UPDATE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "ADMIN_USER_CREATE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "ADMIN_USER_DELETE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "ADMIN_USER_READ" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "ADMIN_USER_UPDATE" }
                });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3de581c4-3f1a-4ac3-a395-24a697eda880"),
                column: "ProfileId",
                value: new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "ADMIN_PROFILE_CREATE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "ADMIN_PROFILE_DELETE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "ADMIN_PROFILE_READ" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "ADMIN_PROFILE_UPDATE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "ADMIN_USER_CREATE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "ADMIN_USER_DELETE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "ADMIN_USER_READ" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "ADMIN_USER_UPDATE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"));

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3de581c4-3f1a-4ac3-a395-24a697eda880"),
                column: "ProfileId",
                value: null);
        }
    }
}
