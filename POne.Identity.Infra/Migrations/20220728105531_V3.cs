using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POne.Identity.Infra.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                column: "Key",
                values: new object[]
                {
                    "FINANCIAL_BANK_CREATE",
                    "FINANCIAL_BANK_DELETE",
                    "FINANCIAL_BANK_READ",
                    "FINANCIAL_BANK_UPDATE",
                    "FINANCIAL_CATEGORY_CREATE",
                    "FINANCIAL_CATEGORY_DELETE",
                    "FINANCIAL_CATEGORY_READ",
                    "FINANCIAL_CATEGORY_UPDATE",
                    "FINANCIAL_DASHBOARD_CREATE",
                    "FINANCIAL_DASHBOARD_DELETE",
                    "FINANCIAL_DASHBOARD_READ",
                    "FINANCIAL_DASHBOARD_UPDATE",
                    "FINANCIAL_ENTRY_CREATE",
                    "FINANCIAL_ENTRY_DELETE",
                    "FINANCIAL_ENTRY_READ",
                    "FINANCIAL_ENTRY_UPDATE",
                    "FINANCIAL_SUB_CATEGORY_CREATE",
                    "FINANCIAL_SUB_CATEGORY_DELETE",
                    "FINANCIAL_SUB_CATEGORY_READ",
                    "FINANCIAL_SUB_CATEGORY_UPDATE",
                    "FINANCIAL_WALLET_CREATE",
                    "FINANCIAL_WALLET_DELETE",
                    "FINANCIAL_WALLET_READ",
                    "FINANCIAL_WALLET_UPDATE"
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "ProfileRoles",
                columns: new[] { "ProfilesId", "RolesKey" },
                values: new object[,]
                {
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_BANK_CREATE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_BANK_DELETE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_BANK_READ" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_BANK_UPDATE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_CATEGORY_CREATE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_CATEGORY_DELETE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_CATEGORY_READ" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_CATEGORY_UPDATE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_DASHBOARD_CREATE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_DASHBOARD_DELETE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_DASHBOARD_READ" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_DASHBOARD_UPDATE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_ENTRY_CREATE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_ENTRY_DELETE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_ENTRY_READ" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_ENTRY_UPDATE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_SUB_CATEGORY_CREATE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_SUB_CATEGORY_DELETE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_SUB_CATEGORY_READ" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_SUB_CATEGORY_UPDATE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_WALLET_CREATE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_WALLET_DELETE" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_WALLET_READ" },
                    { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_WALLET_UPDATE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_BANK_CREATE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_BANK_DELETE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_BANK_READ" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_BANK_UPDATE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_CATEGORY_CREATE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_CATEGORY_DELETE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_CATEGORY_READ" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_CATEGORY_UPDATE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_DASHBOARD_CREATE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_DASHBOARD_DELETE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_DASHBOARD_READ" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_DASHBOARD_UPDATE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_ENTRY_CREATE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_ENTRY_DELETE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_ENTRY_READ" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_ENTRY_UPDATE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_SUB_CATEGORY_CREATE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_SUB_CATEGORY_DELETE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_SUB_CATEGORY_READ" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_SUB_CATEGORY_UPDATE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_WALLET_CREATE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_WALLET_DELETE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_WALLET_READ" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "ProfileRoles",
                keyColumns: new[] { "ProfilesId", "RolesKey" },
                keyValues: new object[] { new Guid("ce3b628f-3561-49e8-9560-6e24ef46dfe8"), "FINANCIAL_WALLET_UPDATE" });

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_BANK_CREATE");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_BANK_DELETE");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_BANK_READ");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_BANK_UPDATE");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_CATEGORY_CREATE");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_CATEGORY_DELETE");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_CATEGORY_READ");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_CATEGORY_UPDATE");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_DASHBOARD_CREATE");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_DASHBOARD_DELETE");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_DASHBOARD_READ");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_DASHBOARD_UPDATE");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_ENTRY_CREATE");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_ENTRY_DELETE");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_ENTRY_READ");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_ENTRY_UPDATE");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_SUB_CATEGORY_CREATE");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_SUB_CATEGORY_DELETE");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_SUB_CATEGORY_READ");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_SUB_CATEGORY_UPDATE");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_WALLET_CREATE");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_WALLET_DELETE");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_WALLET_READ");

            migrationBuilder.DeleteData(
                schema: "auth",
                table: "Roles",
                keyColumn: "Key",
                keyValue: "FINANCIAL_WALLET_UPDATE");
        }
    }
}
