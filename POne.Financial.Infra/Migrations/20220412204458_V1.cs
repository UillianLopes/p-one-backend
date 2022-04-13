using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POne.Financial.Infra.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "fin");

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

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "fin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                schema: "fin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<decimal>(type: "Decimal(10,4)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Agency = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_Banks_BankId",
                        column: x => x.BankId,
                        principalSchema: "fin",
                        principalTable: "Banks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                schema: "fin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "fin",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Balance",
                schema: "fin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<decimal>(type: "Decimal(10,4)", nullable: false),
                    WalletId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Balance_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalSchema: "fin",
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                schema: "fin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecurrenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Recurrences = table.Column<int>(type: "int", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "Decimal(10,4)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BarCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "fin",
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Entries_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalSchema: "fin",
                        principalTable: "SubCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                schema: "fin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<decimal>(type: "Decimal(10,4)", nullable: false),
                    Fees = table.Column<decimal>(type: "Decimal(10,4)", nullable: false),
                    Fine = table.Column<decimal>(type: "Decimal(10,4)", nullable: false),
                    EntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BalanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Entries_EntryId",
                        column: x => x.EntryId,
                        principalSchema: "fin",
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_Wallets_BalanceId",
                        column: x => x.BalanceId,
                        principalSchema: "fin",
                        principalTable: "Wallets",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "fin",
                table: "Banks",
                columns: new[] { "Id", "Code", "Creation", "IsDeleted", "LastUpdate", "Name" },
                values: new object[,]
                {
                    { new Guid("98084106-61f1-11ec-9517-00155d6d9d2f"), "0", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Bankpar S.A." },
                    { new Guid("98084138-61f1-11ec-9517-00155d6d9d2f"), "1", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco do Brasil S.A." },
                    { new Guid("9808413f-61f1-11ec-9517-00155d6d9d2f"), "3", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco da Amazônia S.A." },
                    { new Guid("98084143-61f1-11ec-9517-00155d6d9d2f"), "4", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco do Nordeste do Brasil S.A." },
                    { new Guid("98084146-61f1-11ec-9517-00155d6d9d2f"), "12", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Standard de Investimentos S.A." },
                    { new Guid("98084149-61f1-11ec-9517-00155d6d9d2f"), "14", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Natixis Brasil S.A. Banco Múltiplo" },
                    { new Guid("9808414b-61f1-11ec-9517-00155d6d9d2f"), "19", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Azteca do Brasil S.A." },
                    { new Guid("9808414e-61f1-11ec-9517-00155d6d9d2f"), "21", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "BANESTES S.A. Banco do Estado do Espírito Santo" },
                    { new Guid("98084151-61f1-11ec-9517-00155d6d9d2f"), "24", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco de Pernambuco S.A. – BANDEPE" },
                    { new Guid("98084153-61f1-11ec-9517-00155d6d9d2f"), "25", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Alfa S.A." },
                    { new Guid("98084156-61f1-11ec-9517-00155d6d9d2f"), "29", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Banerj S.A." },
                    { new Guid("9808415a-61f1-11ec-9517-00155d6d9d2f"), "31", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Beg S.A." },
                    { new Guid("9808415d-61f1-11ec-9517-00155d6d9d2f"), "33", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Santander (Brasil) S.A." },
                    { new Guid("9808415f-61f1-11ec-9517-00155d6d9d2f"), "36", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Bradesco BBI S.A." },
                    { new Guid("98084162-61f1-11ec-9517-00155d6d9d2f"), "37", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco do Estado do Pará S.A." },
                    { new Guid("98084165-61f1-11ec-9517-00155d6d9d2f"), "39", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco do Estado do Piauí S.A. – BEP" },
                    { new Guid("98084168-61f1-11ec-9517-00155d6d9d2f"), "40", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Cargill S.A." },
                    { new Guid("9808416b-61f1-11ec-9517-00155d6d9d2f"), "41", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco do Estado do Rio Grande do Sul S.A." },
                    { new Guid("9808416e-61f1-11ec-9517-00155d6d9d2f"), "44", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco BVA S.A." },
                    { new Guid("98084171-61f1-11ec-9517-00155d6d9d2f"), "45", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Opportunity S.A." },
                    { new Guid("98084175-61f1-11ec-9517-00155d6d9d2f"), "47", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco do Estado de Sergipe S.A." },
                    { new Guid("98084178-61f1-11ec-9517-00155d6d9d2f"), "62", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Hipercard Banco Múltiplo S.A." },
                    { new Guid("9808417b-61f1-11ec-9517-00155d6d9d2f"), "63", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Ibi S.A. Banco Múltiplo" },
                    { new Guid("9808417d-61f1-11ec-9517-00155d6d9d2f"), "64", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Goldman Sachs do Brasil Banco Múltiplo S.A." },
                    { new Guid("98084180-61f1-11ec-9517-00155d6d9d2f"), "65", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Bracce S.A." },
                    { new Guid("98084182-61f1-11ec-9517-00155d6d9d2f"), "66", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Morgan Stanley S.A." },
                    { new Guid("98084185-61f1-11ec-9517-00155d6d9d2f"), "69", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "BPN Brasil Banco Múltiplo S.A." },
                    { new Guid("98084187-61f1-11ec-9517-00155d6d9d2f"), "70", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "BRB – Banco de Brasília S.A." },
                    { new Guid("9808418a-61f1-11ec-9517-00155d6d9d2f"), "72", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Rural Mais S.A." },
                    { new Guid("9808418c-61f1-11ec-9517-00155d6d9d2f"), "73", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "BB Banco Popular do Brasil S.A." },
                    { new Guid("9808418e-61f1-11ec-9517-00155d6d9d2f"), "74", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco J. Safra S.A." },
                    { new Guid("98084191-61f1-11ec-9517-00155d6d9d2f"), "75", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco CR2 S.A." },
                    { new Guid("98084193-61f1-11ec-9517-00155d6d9d2f"), "76", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco KDB S.A." },
                    { new Guid("98084195-61f1-11ec-9517-00155d6d9d2f"), "077-9", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Intermedium S.A." },
                    { new Guid("98084197-61f1-11ec-9517-00155d6d9d2f"), "78", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "BES Investimento do Brasil S.A.-Banco de Investimento" },
                    { new Guid("98084199-61f1-11ec-9517-00155d6d9d2f"), "79", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "JBS Banco S.A." },
                    { new Guid("9808419c-61f1-11ec-9517-00155d6d9d2f"), "081-7", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Concórdia Banco S.A." },
                    { new Guid("9808419f-61f1-11ec-9517-00155d6d9d2f"), "082-5", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Topázio S.A." },
                    { new Guid("980841a1-61f1-11ec-9517-00155d6d9d2f"), "083-3", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco da China Brasil S.A." },
                    { new Guid("980841a3-61f1-11ec-9517-00155d6d9d2f"), "84", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Unicred Norte do Paraná" },
                    { new Guid("980841a6-61f1-11ec-9517-00155d6d9d2f"), "085-x", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Cooperativa Central de Crédito Urbano-CECRED" },
                    { new Guid("980841a8-61f1-11ec-9517-00155d6d9d2f"), "086-8", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "OBOE Crédito Financiamento e Investimento S.A." }
                });

            migrationBuilder.InsertData(
                schema: "fin",
                table: "Banks",
                columns: new[] { "Id", "Code", "Creation", "IsDeleted", "LastUpdate", "Name" },
                values: new object[,]
                {
                    { new Guid("980841ab-61f1-11ec-9517-00155d6d9d2f"), "087-6", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Cooperativa Unicred Central Santa Catarina" },
                    { new Guid("980841ae-61f1-11ec-9517-00155d6d9d2f"), "088-4", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Randon S.A." },
                    { new Guid("980841b1-61f1-11ec-9517-00155d6d9d2f"), "089-2", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Cooperativa de Crédito Rural da Região de Mogiana" },
                    { new Guid("980841b3-61f1-11ec-9517-00155d6d9d2f"), "090-2", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Cooperativa Central de Economia e Crédito Mutuo das Unicreds" },
                    { new Guid("980841b5-61f1-11ec-9517-00155d6d9d2f"), "091-4", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Unicred Central do Rio Grande do Sul" },
                    { new Guid("980841b8-61f1-11ec-9517-00155d6d9d2f"), "092-2", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Brickell S.A. Crédito, financiamento e Investimento" },
                    { new Guid("980841ba-61f1-11ec-9517-00155d6d9d2f"), "094-2", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Petra S.A." },
                    { new Guid("980841bc-61f1-11ec-9517-00155d6d9d2f"), "96", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco BM&F de Serviços de Liquidação e Custódia S.A" },
                    { new Guid("980841bf-61f1-11ec-9517-00155d6d9d2f"), "097-3", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Cooperativa Central de Crédito Noroeste Brasileiro Ltda." },
                    { new Guid("980841c1-61f1-11ec-9517-00155d6d9d2f"), "098-1", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Credicorol Cooperativa de Crédito Rural" },
                    { new Guid("980841c4-61f1-11ec-9517-00155d6d9d2f"), "099-x", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Cooperativa Central de Economia e Credito Mutuo das Unicreds" },
                    { new Guid("980841c6-61f1-11ec-9517-00155d6d9d2f"), "104", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Caixa Econômica Federal" },
                    { new Guid("980841c9-61f1-11ec-9517-00155d6d9d2f"), "107", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco BBM S.A." },
                    { new Guid("980841cb-61f1-11ec-9517-00155d6d9d2f"), "168", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "HSBC Finance (Brasil) S.A. – Banco Múltiplo" },
                    { new Guid("980841ce-61f1-11ec-9517-00155d6d9d2f"), "184", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Itaú BBA S.A." },
                    { new Guid("980841d0-61f1-11ec-9517-00155d6d9d2f"), "204", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Bradesco Cartões S.A." },
                    { new Guid("980841d3-61f1-11ec-9517-00155d6d9d2f"), "208", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco BTG Pactual S.A." },
                    { new Guid("980841d8-61f1-11ec-9517-00155d6d9d2f"), "212", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Matone S.A." },
                    { new Guid("980841da-61f1-11ec-9517-00155d6d9d2f"), "213", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Arbi S.A." },
                    { new Guid("980841dd-61f1-11ec-9517-00155d6d9d2f"), "214", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Dibens S.A." },
                    { new Guid("980841e0-61f1-11ec-9517-00155d6d9d2f"), "215", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Comercial e de Investimento Sudameris S.A." },
                    { new Guid("980841e3-61f1-11ec-9517-00155d6d9d2f"), "217", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco John Deere S.A." },
                    { new Guid("980841e5-61f1-11ec-9517-00155d6d9d2f"), "218", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Bonsucesso S.A." },
                    { new Guid("980841e8-61f1-11ec-9517-00155d6d9d2f"), "222", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Credit Agricole Brasil S.A." },
                    { new Guid("980841ea-61f1-11ec-9517-00155d6d9d2f"), "224", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Fibra S.A." },
                    { new Guid("980841ed-61f1-11ec-9517-00155d6d9d2f"), "225", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Brascan S.A." },
                    { new Guid("980841f0-61f1-11ec-9517-00155d6d9d2f"), "229", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Cruzeiro do Sul S.A." },
                    { new Guid("980841f3-61f1-11ec-9517-00155d6d9d2f"), "230", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Unicard Banco Múltiplo S.A." },
                    { new Guid("980841f6-61f1-11ec-9517-00155d6d9d2f"), "233", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco GE Capital S.A." },
                    { new Guid("980841f9-61f1-11ec-9517-00155d6d9d2f"), "237", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Bradesco S.A." },
                    { new Guid("980841fc-61f1-11ec-9517-00155d6d9d2f"), "241", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Clássico S.A." },
                    { new Guid("980841ff-61f1-11ec-9517-00155d6d9d2f"), "243", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Máxima S.A." },
                    { new Guid("98084202-61f1-11ec-9517-00155d6d9d2f"), "246", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco ABC Brasil S.A." },
                    { new Guid("98084205-61f1-11ec-9517-00155d6d9d2f"), "248", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Boavista Interatlântico S.A." },
                    { new Guid("98084207-61f1-11ec-9517-00155d6d9d2f"), "249", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Investcred Unibanco S.A." },
                    { new Guid("9808420a-61f1-11ec-9517-00155d6d9d2f"), "250", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Schahin S.A." },
                    { new Guid("9808420d-61f1-11ec-9517-00155d6d9d2f"), "254", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Paraná Banco S.A." },
                    { new Guid("9808420f-61f1-11ec-9517-00155d6d9d2f"), "263", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Cacique S.A." },
                    { new Guid("98084212-61f1-11ec-9517-00155d6d9d2f"), "265", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Fator S.A." },
                    { new Guid("98084214-61f1-11ec-9517-00155d6d9d2f"), "266", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Cédula S.A." },
                    { new Guid("98084216-61f1-11ec-9517-00155d6d9d2f"), "300", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco de La Nacion Argentina" },
                    { new Guid("98084219-61f1-11ec-9517-00155d6d9d2f"), "318", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco BMG S.A." }
                });

            migrationBuilder.InsertData(
                schema: "fin",
                table: "Banks",
                columns: new[] { "Id", "Code", "Creation", "IsDeleted", "LastUpdate", "Name" },
                values: new object[,]
                {
                    { new Guid("9808421b-61f1-11ec-9517-00155d6d9d2f"), "320", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Industrial e Comercial S.A." },
                    { new Guid("9808421d-61f1-11ec-9517-00155d6d9d2f"), "341", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Itaú Unibanco S.A." },
                    { new Guid("98084220-61f1-11ec-9517-00155d6d9d2f"), "356", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Real S.A." },
                    { new Guid("98084222-61f1-11ec-9517-00155d6d9d2f"), "366", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Société Générale Brasil S.A." },
                    { new Guid("98084224-61f1-11ec-9517-00155d6d9d2f"), "370", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco WestLB do Brasil S.A." },
                    { new Guid("98084227-61f1-11ec-9517-00155d6d9d2f"), "376", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco J. P. Morgan S.A." },
                    { new Guid("98084229-61f1-11ec-9517-00155d6d9d2f"), "389", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Mercantil do Brasil S.A." },
                    { new Guid("9808422b-61f1-11ec-9517-00155d6d9d2f"), "394", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Bradesco Financiamentos S.A." },
                    { new Guid("9808422e-61f1-11ec-9517-00155d6d9d2f"), "399", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "HSBC Bank Brasil S.A. – Banco Múltiplo" },
                    { new Guid("98084230-61f1-11ec-9517-00155d6d9d2f"), "409", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Unibanco – União de Bancos Brasileiros S.A." },
                    { new Guid("98084232-61f1-11ec-9517-00155d6d9d2f"), "412", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Capital S.A." },
                    { new Guid("98084235-61f1-11ec-9517-00155d6d9d2f"), "422", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Safra S.A." },
                    { new Guid("98084238-61f1-11ec-9517-00155d6d9d2f"), "453", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Rural S.A." },
                    { new Guid("9808423b-61f1-11ec-9517-00155d6d9d2f"), "456", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco de Tokyo-Mitsubishi UFJ Brasil S.A." },
                    { new Guid("9808423d-61f1-11ec-9517-00155d6d9d2f"), "464", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Sumitomo Mitsui Brasileiro S.A." },
                    { new Guid("98084240-61f1-11ec-9517-00155d6d9d2f"), "473", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Caixa Geral – Brasil S.A." },
                    { new Guid("98084243-61f1-11ec-9517-00155d6d9d2f"), "477", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Citibank N.A." },
                    { new Guid("98084245-61f1-11ec-9517-00155d6d9d2f"), "479", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco ItaúBank S.A" },
                    { new Guid("98084248-61f1-11ec-9517-00155d6d9d2f"), "487", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Deutsche Bank S.A. – Banco Alemão" },
                    { new Guid("9808424b-61f1-11ec-9517-00155d6d9d2f"), "488", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "JPMorgan Chase Bank" },
                    { new Guid("9808424d-61f1-11ec-9517-00155d6d9d2f"), "492", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "ING Bank N.V." },
                    { new Guid("98084250-61f1-11ec-9517-00155d6d9d2f"), "494", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco de La Republica Oriental del Uruguay" },
                    { new Guid("98084252-61f1-11ec-9517-00155d6d9d2f"), "495", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco de La Provincia de Buenos Aires" },
                    { new Guid("98084256-61f1-11ec-9517-00155d6d9d2f"), "505", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Credit Suisse (Brasil) S.A." },
                    { new Guid("98084259-61f1-11ec-9517-00155d6d9d2f"), "600", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Luso Brasileiro S.A." },
                    { new Guid("9808425c-61f1-11ec-9517-00155d6d9d2f"), "604", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Industrial do Brasil S.A." },
                    { new Guid("98084260-61f1-11ec-9517-00155d6d9d2f"), "610", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco VR S.A." },
                    { new Guid("98084262-61f1-11ec-9517-00155d6d9d2f"), "611", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Paulista S.A." },
                    { new Guid("98084265-61f1-11ec-9517-00155d6d9d2f"), "612", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Guanabara S.A." },
                    { new Guid("98084268-61f1-11ec-9517-00155d6d9d2f"), "613", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Pecúnia S.A." },
                    { new Guid("9808426a-61f1-11ec-9517-00155d6d9d2f"), "623", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Panamericano S.A." },
                    { new Guid("9808426c-61f1-11ec-9517-00155d6d9d2f"), "626", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Ficsa S.A." },
                    { new Guid("9808426f-61f1-11ec-9517-00155d6d9d2f"), "630", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Intercap S.A." },
                    { new Guid("98084271-61f1-11ec-9517-00155d6d9d2f"), "633", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Rendimento S.A." },
                    { new Guid("98084273-61f1-11ec-9517-00155d6d9d2f"), "634", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Triângulo S.A." },
                    { new Guid("98084276-61f1-11ec-9517-00155d6d9d2f"), "637", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Sofisa S.A." },
                    { new Guid("98084278-61f1-11ec-9517-00155d6d9d2f"), "638", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Prosper S.A." },
                    { new Guid("9808427b-61f1-11ec-9517-00155d6d9d2f"), "641", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Alvorada S.A." },
                    { new Guid("9808427d-61f1-11ec-9517-00155d6d9d2f"), "643", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Pine S.A." },
                    { new Guid("9808427f-61f1-11ec-9517-00155d6d9d2f"), "652", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Itaú Unibanco Holding S.A." },
                    { new Guid("98084282-61f1-11ec-9517-00155d6d9d2f"), "653", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Indusval S.A." },
                    { new Guid("98084285-61f1-11ec-9517-00155d6d9d2f"), "654", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco A.J.Renner S.A." }
                });

            migrationBuilder.InsertData(
                schema: "fin",
                table: "Banks",
                columns: new[] { "Id", "Code", "Creation", "IsDeleted", "LastUpdate", "Name" },
                values: new object[,]
                {
                    { new Guid("98084288-61f1-11ec-9517-00155d6d9d2f"), "655", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Votorantim S.A." },
                    { new Guid("9808428a-61f1-11ec-9517-00155d6d9d2f"), "707", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Daycoval S.A." },
                    { new Guid("9808428d-61f1-11ec-9517-00155d6d9d2f"), "719", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banif-Banco Internacional do Funchal (Brasil)S.A." },
                    { new Guid("9808428f-61f1-11ec-9517-00155d6d9d2f"), "721", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Credibel S.A." },
                    { new Guid("98084291-61f1-11ec-9517-00155d6d9d2f"), "724", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Porto Seguro S.A." },
                    { new Guid("98084294-61f1-11ec-9517-00155d6d9d2f"), "734", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Gerdau S.A." },
                    { new Guid("98084296-61f1-11ec-9517-00155d6d9d2f"), "735", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Pottencial S.A." },
                    { new Guid("98084299-61f1-11ec-9517-00155d6d9d2f"), "738", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Morada S.A." },
                    { new Guid("9808429b-61f1-11ec-9517-00155d6d9d2f"), "739", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco BGN S.A." },
                    { new Guid("9808429f-61f1-11ec-9517-00155d6d9d2f"), "740", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Barclays S.A." },
                    { new Guid("980842a1-61f1-11ec-9517-00155d6d9d2f"), "741", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Ribeirão Preto S.A." },
                    { new Guid("980842a3-61f1-11ec-9517-00155d6d9d2f"), "743", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Semear S.A." },
                    { new Guid("980842a6-61f1-11ec-9517-00155d6d9d2f"), "744", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "BankBoston N.A." },
                    { new Guid("980842a8-61f1-11ec-9517-00155d6d9d2f"), "745", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Citibank S.A." },
                    { new Guid("980842ab-61f1-11ec-9517-00155d6d9d2f"), "746", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Modal S.A." },
                    { new Guid("980842ae-61f1-11ec-9517-00155d6d9d2f"), "747", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Rabobank International Brasil S.A." },
                    { new Guid("980842b1-61f1-11ec-9517-00155d6d9d2f"), "748", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Cooperativo Sicredi S.A." },
                    { new Guid("980842b3-61f1-11ec-9517-00155d6d9d2f"), "749", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Simples S.A." },
                    { new Guid("980842b6-61f1-11ec-9517-00155d6d9d2f"), "751", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Dresdner Bank Brasil S.A. – Banco Múltiplo" },
                    { new Guid("980842b8-61f1-11ec-9517-00155d6d9d2f"), "752", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco BNP Paribas Brasil S.A." },
                    { new Guid("980842bb-61f1-11ec-9517-00155d6d9d2f"), "753", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "NBC Bank Brasil S.A. – Banco Múltiplo" },
                    { new Guid("980842c3-61f1-11ec-9517-00155d6d9d2f"), "755", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Bank of America Merrill Lynch Banco Múltiplo S.A." },
                    { new Guid("980842c7-61f1-11ec-9517-00155d6d9d2f"), "756", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Cooperativo do Brasil S.A. – BANCOOB" },
                    { new Guid("980842ca-61f1-11ec-9517-00155d6d9d2f"), "757", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco KEB do Brasil S.A." },
                    { new Guid("980842cd-61f1-11ec-9517-00155d6d9d2f"), "M10", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Moneo S.A." },
                    { new Guid("980842d0-61f1-11ec-9517-00155d6d9d2f"), "M11", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco IBM S.A." },
                    { new Guid("980842d3-61f1-11ec-9517-00155d6d9d2f"), "M20", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Toyota do Brasil S.A." },
                    { new Guid("980842d6-61f1-11ec-9517-00155d6d9d2f"), "M21", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Daimlerchrysler S.A." },
                    { new Guid("980842da-61f1-11ec-9517-00155d6d9d2f"), "M03", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Fiat S.A." },
                    { new Guid("980842dd-61f1-11ec-9517-00155d6d9d2f"), "M12", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Maxinvest S.A." },
                    { new Guid("980842df-61f1-11ec-9517-00155d6d9d2f"), "M22", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Honda S.A." },
                    { new Guid("980842e2-61f1-11ec-9517-00155d6d9d2f"), "M13", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Tricury S.A." },
                    { new Guid("980842e4-61f1-11ec-9517-00155d6d9d2f"), "M14", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Volkswagen S.A." },
                    { new Guid("980842e7-61f1-11ec-9517-00155d6d9d2f"), "M23", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Volvo (Brasil) S.A." },
                    { new Guid("980842ea-61f1-11ec-9517-00155d6d9d2f"), "M15", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco BRJ S.A." },
                    { new Guid("980842ed-61f1-11ec-9517-00155d6d9d2f"), "M06", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco de Lage Landen Brasil S.A." },
                    { new Guid("980842f0-61f1-11ec-9517-00155d6d9d2f"), "M24", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco PSA Finance Brasil S.A." },
                    { new Guid("980842f3-61f1-11ec-9517-00155d6d9d2f"), "M07", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco GMAC S.A." },
                    { new Guid("980842f5-61f1-11ec-9517-00155d6d9d2f"), "M16", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Rodobens S.A." },
                    { new Guid("980842f8-61f1-11ec-9517-00155d6d9d2f"), "M08", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Citicard S.A." },
                    { new Guid("980842fa-61f1-11ec-9517-00155d6d9d2f"), "M17", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Ourinvest S.A." },
                    { new Guid("980842fd-61f1-11ec-9517-00155d6d9d2f"), "M18", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Ford S.A." }
                });

            migrationBuilder.InsertData(
                schema: "fin",
                table: "Banks",
                columns: new[] { "Id", "Code", "Creation", "IsDeleted", "LastUpdate", "Name" },
                values: new object[] { new Guid("98084300-61f1-11ec-9517-00155d6d9d2f"), "M09", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco Itaucred Financiamentos S.A." });

            migrationBuilder.InsertData(
                schema: "fin",
                table: "Banks",
                columns: new[] { "Id", "Code", "Creation", "IsDeleted", "LastUpdate", "Name" },
                values: new object[] { new Guid("98084303-61f1-11ec-9517-00155d6d9d2f"), "M19", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco CNH Capital S.A." });

            migrationBuilder.InsertData(
                schema: "fin",
                table: "Banks",
                columns: new[] { "Id", "Code", "Creation", "IsDeleted", "LastUpdate", "Name" },
                values: new object[] { new Guid("98084306-61f1-11ec-9517-00155d6d9d2f"), "M19", new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 2, 19, 21, 0, 0, 0, DateTimeKind.Local), "Banco CNH Capital S.A." });

            migrationBuilder.CreateIndex(
                name: "IX_Balance_WalletId",
                schema: "fin",
                table: "Balance",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserId",
                schema: "fin",
                table: "Categories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_CategoryId",
                schema: "fin",
                table: "Entries",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_RecurrenceId",
                schema: "fin",
                table: "Entries",
                column: "RecurrenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_SubCategoryId",
                schema: "fin",
                table: "Entries",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_UserId",
                schema: "fin",
                table: "Entries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_BalanceId",
                schema: "fin",
                table: "Payment",
                column: "BalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_EntryId",
                schema: "fin",
                table: "Payment",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                schema: "fin",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_BankId",
                schema: "fin",
                table: "Wallets",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                schema: "fin",
                table: "Wallets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balance",
                schema: "fin");

            migrationBuilder.DropTable(
                name: "Payment",
                schema: "fin");

            migrationBuilder.DropTable(
                name: "Entries",
                schema: "fin");

            migrationBuilder.DropTable(
                name: "Wallets",
                schema: "fin");

            migrationBuilder.DropTable(
                name: "SubCategories",
                schema: "fin");

            migrationBuilder.DropTable(
                name: "Banks",
                schema: "fin");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "fin");
        }
    }
}
