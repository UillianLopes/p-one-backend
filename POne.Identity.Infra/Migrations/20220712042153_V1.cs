using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POne.Identity.Infra.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "auth",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileRoles",
                schema: "auth",
                columns: table => new
                {
                    ProfilesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolesKey = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileRoles", x => new { x.ProfilesId, x.RolesKey });
                    table.ForeignKey(
                        name: "FK_ProfileRoles_Profiles_ProfilesId",
                        column: x => x.ProfilesId,
                        principalSchema: "auth",
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileRoles_Roles_RolesKey",
                        column: x => x.RolesKey,
                        principalSchema: "auth",
                        principalTable: "Roles",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
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
                    Password_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Settings_Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Users_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "auth",
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number_CountryCode = table.Column<int>(type: "int", nullable: true),
                    Number_Number = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Creation", "Description", "IsDeleted", "LastUpdate", "Name" },
                values: new object[] { new Guid("ce4b628f-3561-49e8-9560-5e16ef46dfe9"), new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "POne Main Account", false, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "POne" });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Roles",
                column: "Key",
                values: new object[]
                {
                    "ADMIN_PROFILE_CREATE",
                    "ADMIN_PROFILE_DELETE",
                    "ADMIN_PROFILE_READ",
                    "ADMIN_PROFILE_UPDATE",
                    "ADMIN_USER_CREATE",
                    "ADMIN_USER_DELETE",
                    "ADMIN_USER_READ",
                    "ADMIN_USER_UPDATE"
                });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Users",
                columns: new[] { "Id", "AccountId", "BirthDate", "Creation", "Email", "IsDeleted", "LastUpdate", "Name", "ProfileId", "Address_City", "Address_Country", "Address_District", "Address_Number", "Address_State", "Address_Street", "Address_ZipCode", "Password_Value", "Settings_Value" },
                values: new object[] { new Guid("3de581c4-3f1a-4ac3-a395-24a697eda880"), new Guid("ce4b628f-3561-49e8-9560-5e16ef46dfe9"), new DateTime(1996, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "uilliansl@outlook.com", false, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uillian de Souza Lopes", null, "Serra", "Brazil", "Praia de capuba", "20", "ES", "Rua Dolores Araujo de Oliveira", "29173660", "$2a$11$uxW.fi50RNvTC.GOq20dXu0mZzJ.wIAbjd2V5hEhm.YB62v1V1yIG", "eyAiTGFuZ3VhZ2UiOiAicHQtQlIiIH0=" });

            migrationBuilder.InsertData(
                schema: "auth",
                table: "Contacts",
                columns: new[] { "Id", "Creation", "IsDeleted", "LastUpdate", "Name", "UserId", "Number_CountryCode", "Number_Number" },
                values: new object[] { new Guid("6459b59a-ef4b-4d0c-bc63-4657e262701c"), new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test contact", new Guid("3de581c4-3f1a-4ac3-a395-24a697eda880"), 55, "999998888" });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                schema: "auth",
                table: "Contacts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileRoles_RolesKey",
                schema: "auth",
                table: "ProfileRoles",
                column: "RolesKey");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_AccountId",
                schema: "auth",
                table: "Profiles",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountId",
                schema: "auth",
                table: "Users",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileId",
                schema: "auth",
                table: "Users",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "ProfileRoles",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Profiles",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
