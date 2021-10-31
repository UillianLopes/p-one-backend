using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POne.Identity.Infra.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    ParentAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Accounts_ParentAccountId",
                        column: x => x.ParentAccountId,
                        principalSchema: "auth",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    Address_District = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Address_Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Address_City = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Address_State = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Address_Country = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MobilePhone_CountryCode = table.Column<int>(type: "int", nullable: true),
                    MobilePhone_Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Password_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileRole",
                schema: "auth",
                columns: table => new
                {
                    ProfilesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileRole", x => new { x.ProfilesId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_ProfileRole_Profiles_ProfilesId",
                        column: x => x.ProfilesId,
                        principalSchema: "auth",
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileRole_Roles_RolesId",
                        column: x => x.RolesId,
                        principalSchema: "auth",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountUser",
                schema: "auth",
                columns: table => new
                {
                    AccountsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountUser", x => new { x.AccountsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AccountUser_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalSchema: "auth",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                schema: "auth",
                columns: table => new
                {
                    RolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Roles_RolesId",
                        column: x => x.RolesId,
                        principalSchema: "auth",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Accounts",
                columns: new[] { "Id", "Creation", "Email", "IsDeleted", "LastUpdate", "Name", "ParentAccountId" },
                values: new object[] { new Guid("ce4b628f-3561-49e8-9560-6e16ef46dfe6"), new DateTime(2021, 10, 25, 17, 53, 17, 995, DateTimeKind.Local).AddTicks(9470), "uilliansl@outlook.com", false, new DateTime(2021, 10, 25, 17, 53, 17, 995, DateTimeKind.Local).AddTicks(9478), "Uillian de Souza Lopes", null });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Creation", "Email", "IsDeleted", "LastUpdate", "Name", "Address_City", "Address_Country", "Address_District", "Address_Number", "Address_State", "Address_Street", "Address_ZipCode", "Password_Value", "MobilePhone_CountryCode", "MobilePhone_Number" },
                values: new object[] { new Guid("3de581c4-3f1a-4ac3-a395-24a697eda880"), new DateTime(1996, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 25, 17, 53, 17, 991, DateTimeKind.Local).AddTicks(2858), "uilliansl@outlook.com", false, new DateTime(2021, 10, 25, 17, 53, 17, 991, DateTimeKind.Local).AddTicks(9693), "Uillian de Souza Lopes", "Serra", "Brazil", "Praia de capuba", "20", "ES", "Rua Dolores Araujo de Oliveira", "29173660", "$2a$11$SEyMRQIEAnJV1tHqZKTkruImz5inNLuanzqBxpCg4r9IKegFjeexO", 55, "27998321849" });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ParentAccountId",
                schema: "auth",
                table: "Accounts",
                column: "ParentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUser_UsersId",
                schema: "auth",
                table: "AccountUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileRole_RolesId",
                schema: "auth",
                table: "ProfileRole",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                schema: "auth",
                table: "RoleUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountUser",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "ProfileRole",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "RoleUser",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Profiles",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "auth");
        }
    }
}
