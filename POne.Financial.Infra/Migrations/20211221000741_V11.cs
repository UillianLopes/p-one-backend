using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POne.Financial.Infra.Migrations
{
    public partial class V11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "fin",
                table: "Banks",
                columns: new[] { "Id", "Code", "Creation", "IsDeleted", "LastUpdate", "Name" },
                values: new object[,]
                {
                    { new Guid("98084106-61f1-11ec-9517-00155d6d9d2f"), "0", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1107), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1117), "Banco Bankpar S.A." },
                    { new Guid("98084138-61f1-11ec-9517-00155d6d9d2f"), "1", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1119), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1120), "Banco do Brasil S.A." },
                    { new Guid("9808413f-61f1-11ec-9517-00155d6d9d2f"), "3", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1121), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1122), "Banco da Amazônia S.A." },
                    { new Guid("98084143-61f1-11ec-9517-00155d6d9d2f"), "4", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1123), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1123), "Banco do Nordeste do Brasil S.A." },
                    { new Guid("98084146-61f1-11ec-9517-00155d6d9d2f"), "12", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1124), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1124), "Banco Standard de Investimentos S.A." },
                    { new Guid("98084149-61f1-11ec-9517-00155d6d9d2f"), "14", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1125), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1125), "Natixis Brasil S.A. Banco Múltiplo" },
                    { new Guid("9808414b-61f1-11ec-9517-00155d6d9d2f"), "19", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1127), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1127), "Banco Azteca do Brasil S.A." },
                    { new Guid("9808414e-61f1-11ec-9517-00155d6d9d2f"), "21", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1128), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1128), "BANESTES S.A. Banco do Estado do Espírito Santo" },
                    { new Guid("98084151-61f1-11ec-9517-00155d6d9d2f"), "24", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1129), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1130), "Banco de Pernambuco S.A. – BANDEPE" },
                    { new Guid("98084153-61f1-11ec-9517-00155d6d9d2f"), "25", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1130), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1131), "Banco Alfa S.A." },
                    { new Guid("98084156-61f1-11ec-9517-00155d6d9d2f"), "29", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1132), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1132), "Banco Banerj S.A." },
                    { new Guid("9808415a-61f1-11ec-9517-00155d6d9d2f"), "31", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1133), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1133), "Banco Beg S.A." },
                    { new Guid("9808415d-61f1-11ec-9517-00155d6d9d2f"), "33", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1136), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1136), "Banco Santander (Brasil) S.A." },
                    { new Guid("9808415f-61f1-11ec-9517-00155d6d9d2f"), "36", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1137), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1137), "Banco Bradesco BBI S.A." },
                    { new Guid("98084162-61f1-11ec-9517-00155d6d9d2f"), "37", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1138), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1138), "Banco do Estado do Pará S.A." },
                    { new Guid("98084165-61f1-11ec-9517-00155d6d9d2f"), "39", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1139), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1140), "Banco do Estado do Piauí S.A. – BEP" },
                    { new Guid("98084168-61f1-11ec-9517-00155d6d9d2f"), "40", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1140), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1141), "Banco Cargill S.A." },
                    { new Guid("9808416b-61f1-11ec-9517-00155d6d9d2f"), "41", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1142), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1142), "Banco do Estado do Rio Grande do Sul S.A." },
                    { new Guid("9808416e-61f1-11ec-9517-00155d6d9d2f"), "44", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1143), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1143), "Banco BVA S.A." },
                    { new Guid("98084171-61f1-11ec-9517-00155d6d9d2f"), "45", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1144), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1144), "Banco Opportunity S.A." },
                    { new Guid("98084175-61f1-11ec-9517-00155d6d9d2f"), "47", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1145), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1145), "Banco do Estado de Sergipe S.A." },
                    { new Guid("98084178-61f1-11ec-9517-00155d6d9d2f"), "62", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1146), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1147), "Hipercard Banco Múltiplo S.A." },
                    { new Guid("9808417b-61f1-11ec-9517-00155d6d9d2f"), "63", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1147), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1148), "Banco Ibi S.A. Banco Múltiplo" },
                    { new Guid("9808417d-61f1-11ec-9517-00155d6d9d2f"), "64", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1148), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1149), "Goldman Sachs do Brasil Banco Múltiplo S.A." },
                    { new Guid("98084180-61f1-11ec-9517-00155d6d9d2f"), "65", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1150), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1150), "Banco Bracce S.A." },
                    { new Guid("98084182-61f1-11ec-9517-00155d6d9d2f"), "66", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1151), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1151), "Banco Morgan Stanley S.A." },
                    { new Guid("98084185-61f1-11ec-9517-00155d6d9d2f"), "69", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1152), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1152), "BPN Brasil Banco Múltiplo S.A." },
                    { new Guid("98084187-61f1-11ec-9517-00155d6d9d2f"), "70", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1153), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1154), "BRB – Banco de Brasília S.A." },
                    { new Guid("9808418a-61f1-11ec-9517-00155d6d9d2f"), "72", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1154), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1155), "Banco Rural Mais S.A." },
                    { new Guid("9808418c-61f1-11ec-9517-00155d6d9d2f"), "73", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1156), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1156), "BB Banco Popular do Brasil S.A." },
                    { new Guid("9808418e-61f1-11ec-9517-00155d6d9d2f"), "74", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1157), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1157), "Banco J. Safra S.A." },
                    { new Guid("98084191-61f1-11ec-9517-00155d6d9d2f"), "75", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1158), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1158), "Banco CR2 S.A." },
                    { new Guid("98084193-61f1-11ec-9517-00155d6d9d2f"), "76", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1159), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1159), "Banco KDB S.A." },
                    { new Guid("98084195-61f1-11ec-9517-00155d6d9d2f"), "077-9", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1160), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1161), "Banco Intermedium S.A." },
                    { new Guid("98084197-61f1-11ec-9517-00155d6d9d2f"), "78", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1161), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1162), "BES Investimento do Brasil S.A.-Banco de Investimento" },
                    { new Guid("98084199-61f1-11ec-9517-00155d6d9d2f"), "79", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1162), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1163), "JBS Banco S.A." },
                    { new Guid("9808419c-61f1-11ec-9517-00155d6d9d2f"), "081-7", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1164), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1164), "Concórdia Banco S.A." },
                    { new Guid("9808419f-61f1-11ec-9517-00155d6d9d2f"), "082-5", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1165), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1165), "Banco Topázio S.A." },
                    { new Guid("980841a1-61f1-11ec-9517-00155d6d9d2f"), "083-3", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1166), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1166), "Banco da China Brasil S.A." },
                    { new Guid("980841a3-61f1-11ec-9517-00155d6d9d2f"), "84", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1167), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1167), "Unicred Norte do Paraná" },
                    { new Guid("980841a6-61f1-11ec-9517-00155d6d9d2f"), "085-x", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1168), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1169), "Cooperativa Central de Crédito Urbano-CECRED" },
                    { new Guid("980841a8-61f1-11ec-9517-00155d6d9d2f"), "086-8", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1169), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1170), "OBOE Crédito Financiamento e Investimento S.A." }
                });

            migrationBuilder.InsertData(
                schema: "fin",
                table: "Banks",
                columns: new[] { "Id", "Code", "Creation", "IsDeleted", "LastUpdate", "Name" },
                values: new object[,]
                {
                    { new Guid("980841ab-61f1-11ec-9517-00155d6d9d2f"), "087-6", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1171), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1171), "Cooperativa Unicred Central Santa Catarina" },
                    { new Guid("980841ae-61f1-11ec-9517-00155d6d9d2f"), "088-4", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1172), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1172), "Banco Randon S.A." },
                    { new Guid("980841b1-61f1-11ec-9517-00155d6d9d2f"), "089-2", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1173), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1173), "Cooperativa de Crédito Rural da Região de Mogiana" },
                    { new Guid("980841b3-61f1-11ec-9517-00155d6d9d2f"), "090-2", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1174), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1175), "Cooperativa Central de Economia e Crédito Mutuo das Unicreds" },
                    { new Guid("980841b5-61f1-11ec-9517-00155d6d9d2f"), "091-4", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1175), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1176), "Unicred Central do Rio Grande do Sul" },
                    { new Guid("980841b8-61f1-11ec-9517-00155d6d9d2f"), "092-2", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1176), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1177), "Brickell S.A. Crédito, financiamento e Investimento" },
                    { new Guid("980841ba-61f1-11ec-9517-00155d6d9d2f"), "094-2", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1178), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1178), "Banco Petra S.A." },
                    { new Guid("980841bc-61f1-11ec-9517-00155d6d9d2f"), "96", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1179), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1179), "Banco BM&F de Serviços de Liquidação e Custódia S.A" },
                    { new Guid("980841bf-61f1-11ec-9517-00155d6d9d2f"), "097-3", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1180), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1180), "Cooperativa Central de Crédito Noroeste Brasileiro Ltda." },
                    { new Guid("980841c1-61f1-11ec-9517-00155d6d9d2f"), "098-1", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1181), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1182), "Credicorol Cooperativa de Crédito Rural" },
                    { new Guid("980841c4-61f1-11ec-9517-00155d6d9d2f"), "099-x", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1182), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1183), "Cooperativa Central de Economia e Credito Mutuo das Unicreds" },
                    { new Guid("980841c6-61f1-11ec-9517-00155d6d9d2f"), "104", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1183), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1184), "Caixa Econômica Federal" },
                    { new Guid("980841c9-61f1-11ec-9517-00155d6d9d2f"), "107", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1185), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1185), "Banco BBM S.A." },
                    { new Guid("980841cb-61f1-11ec-9517-00155d6d9d2f"), "168", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1186), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1186), "HSBC Finance (Brasil) S.A. – Banco Múltiplo" },
                    { new Guid("980841ce-61f1-11ec-9517-00155d6d9d2f"), "184", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1187), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1187), "Banco Itaú BBA S.A." },
                    { new Guid("980841d0-61f1-11ec-9517-00155d6d9d2f"), "204", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1188), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1189), "Banco Bradesco Cartões S.A." },
                    { new Guid("980841d3-61f1-11ec-9517-00155d6d9d2f"), "208", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1189), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1190), "Banco BTG Pactual S.A." },
                    { new Guid("980841d8-61f1-11ec-9517-00155d6d9d2f"), "212", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1190), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1191), "Banco Matone S.A." },
                    { new Guid("980841da-61f1-11ec-9517-00155d6d9d2f"), "213", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1192), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1192), "Banco Arbi S.A." },
                    { new Guid("980841dd-61f1-11ec-9517-00155d6d9d2f"), "214", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1193), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1193), "Banco Dibens S.A." },
                    { new Guid("980841e0-61f1-11ec-9517-00155d6d9d2f"), "215", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1194), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1194), "Banco Comercial e de Investimento Sudameris S.A." },
                    { new Guid("980841e3-61f1-11ec-9517-00155d6d9d2f"), "217", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1195), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1195), "Banco John Deere S.A." },
                    { new Guid("980841e5-61f1-11ec-9517-00155d6d9d2f"), "218", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1196), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1197), "Banco Bonsucesso S.A." },
                    { new Guid("980841e8-61f1-11ec-9517-00155d6d9d2f"), "222", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1197), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1198), "Banco Credit Agricole Brasil S.A." },
                    { new Guid("980841ea-61f1-11ec-9517-00155d6d9d2f"), "224", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1199), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1199), "Banco Fibra S.A." },
                    { new Guid("980841ed-61f1-11ec-9517-00155d6d9d2f"), "225", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1200), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1200), "Banco Brascan S.A." },
                    { new Guid("980841f0-61f1-11ec-9517-00155d6d9d2f"), "229", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1201), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1201), "Banco Cruzeiro do Sul S.A." },
                    { new Guid("980841f3-61f1-11ec-9517-00155d6d9d2f"), "230", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1202), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1202), "Unicard Banco Múltiplo S.A." },
                    { new Guid("980841f6-61f1-11ec-9517-00155d6d9d2f"), "233", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1203), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1204), "Banco GE Capital S.A." },
                    { new Guid("980841f9-61f1-11ec-9517-00155d6d9d2f"), "237", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1204), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1205), "Banco Bradesco S.A." },
                    { new Guid("980841fc-61f1-11ec-9517-00155d6d9d2f"), "241", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1206), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1206), "Banco Clássico S.A." },
                    { new Guid("980841ff-61f1-11ec-9517-00155d6d9d2f"), "243", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1207), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1207), "Banco Máxima S.A." },
                    { new Guid("98084202-61f1-11ec-9517-00155d6d9d2f"), "246", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1208), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1208), "Banco ABC Brasil S.A." },
                    { new Guid("98084205-61f1-11ec-9517-00155d6d9d2f"), "248", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1209), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1209), "Banco Boavista Interatlântico S.A." },
                    { new Guid("98084207-61f1-11ec-9517-00155d6d9d2f"), "249", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1210), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1210), "Banco Investcred Unibanco S.A." },
                    { new Guid("9808420a-61f1-11ec-9517-00155d6d9d2f"), "250", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1211), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1212), "Banco Schahin S.A." },
                    { new Guid("9808420d-61f1-11ec-9517-00155d6d9d2f"), "254", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1212), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1213), "Paraná Banco S.A." },
                    { new Guid("9808420f-61f1-11ec-9517-00155d6d9d2f"), "263", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1214), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1214), "Banco Cacique S.A." },
                    { new Guid("98084212-61f1-11ec-9517-00155d6d9d2f"), "265", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1215), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1215), "Banco Fator S.A." },
                    { new Guid("98084214-61f1-11ec-9517-00155d6d9d2f"), "266", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1216), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1216), "Banco Cédula S.A." },
                    { new Guid("98084216-61f1-11ec-9517-00155d6d9d2f"), "300", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1217), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1217), "Banco de La Nacion Argentina" },
                    { new Guid("98084219-61f1-11ec-9517-00155d6d9d2f"), "318", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1218), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1219), "Banco BMG S.A." }
                });

            migrationBuilder.InsertData(
                schema: "fin",
                table: "Banks",
                columns: new[] { "Id", "Code", "Creation", "IsDeleted", "LastUpdate", "Name" },
                values: new object[,]
                {
                    { new Guid("9808421b-61f1-11ec-9517-00155d6d9d2f"), "320", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1219), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1220), "Banco Industrial e Comercial S.A." },
                    { new Guid("9808421d-61f1-11ec-9517-00155d6d9d2f"), "341", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1221), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1221), "Itaú Unibanco S.A." },
                    { new Guid("98084220-61f1-11ec-9517-00155d6d9d2f"), "356", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1222), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1222), "Banco Real S.A." },
                    { new Guid("98084222-61f1-11ec-9517-00155d6d9d2f"), "366", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1223), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1223), "Banco Société Générale Brasil S.A." },
                    { new Guid("98084224-61f1-11ec-9517-00155d6d9d2f"), "370", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1224), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1225), "Banco WestLB do Brasil S.A." },
                    { new Guid("98084227-61f1-11ec-9517-00155d6d9d2f"), "376", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1225), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1226), "Banco J. P. Morgan S.A." },
                    { new Guid("98084229-61f1-11ec-9517-00155d6d9d2f"), "389", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1226), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1227), "Banco Mercantil do Brasil S.A." },
                    { new Guid("9808422b-61f1-11ec-9517-00155d6d9d2f"), "394", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1228), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1228), "Banco Bradesco Financiamentos S.A." },
                    { new Guid("9808422e-61f1-11ec-9517-00155d6d9d2f"), "399", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1229), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1229), "HSBC Bank Brasil S.A. – Banco Múltiplo" },
                    { new Guid("98084230-61f1-11ec-9517-00155d6d9d2f"), "409", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1230), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1230), "Unibanco – União de Bancos Brasileiros S.A." },
                    { new Guid("98084232-61f1-11ec-9517-00155d6d9d2f"), "412", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1231), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1231), "Banco Capital S.A." },
                    { new Guid("98084235-61f1-11ec-9517-00155d6d9d2f"), "422", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1232), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1233), "Banco Safra S.A." },
                    { new Guid("98084238-61f1-11ec-9517-00155d6d9d2f"), "453", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1233), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1234), "Banco Rural S.A." },
                    { new Guid("9808423b-61f1-11ec-9517-00155d6d9d2f"), "456", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1235), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1235), "Banco de Tokyo-Mitsubishi UFJ Brasil S.A." },
                    { new Guid("9808423d-61f1-11ec-9517-00155d6d9d2f"), "464", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1236), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1236), "Banco Sumitomo Mitsui Brasileiro S.A." },
                    { new Guid("98084240-61f1-11ec-9517-00155d6d9d2f"), "473", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1237), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1237), "Banco Caixa Geral – Brasil S.A." },
                    { new Guid("98084243-61f1-11ec-9517-00155d6d9d2f"), "477", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1238), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1238), "Citibank N.A." },
                    { new Guid("98084245-61f1-11ec-9517-00155d6d9d2f"), "479", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1239), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1240), "Banco ItaúBank S.A" },
                    { new Guid("98084248-61f1-11ec-9517-00155d6d9d2f"), "487", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1240), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1241), "Deutsche Bank S.A. – Banco Alemão" },
                    { new Guid("9808424b-61f1-11ec-9517-00155d6d9d2f"), "488", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1241), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1242), "JPMorgan Chase Bank" },
                    { new Guid("9808424d-61f1-11ec-9517-00155d6d9d2f"), "492", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1242), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1243), "ING Bank N.V." },
                    { new Guid("98084250-61f1-11ec-9517-00155d6d9d2f"), "494", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1244), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1244), "Banco de La Republica Oriental del Uruguay" },
                    { new Guid("98084252-61f1-11ec-9517-00155d6d9d2f"), "495", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1245), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1245), "Banco de La Provincia de Buenos Aires" },
                    { new Guid("98084256-61f1-11ec-9517-00155d6d9d2f"), "505", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1246), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1246), "Banco Credit Suisse (Brasil) S.A." },
                    { new Guid("98084259-61f1-11ec-9517-00155d6d9d2f"), "600", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1247), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1247), "Banco Luso Brasileiro S.A." },
                    { new Guid("9808425c-61f1-11ec-9517-00155d6d9d2f"), "604", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1266), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1267), "Banco Industrial do Brasil S.A." },
                    { new Guid("98084260-61f1-11ec-9517-00155d6d9d2f"), "610", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1268), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1268), "Banco VR S.A." },
                    { new Guid("98084262-61f1-11ec-9517-00155d6d9d2f"), "611", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1269), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1269), "Banco Paulista S.A." },
                    { new Guid("98084265-61f1-11ec-9517-00155d6d9d2f"), "612", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1270), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1270), "Banco Guanabara S.A." },
                    { new Guid("98084268-61f1-11ec-9517-00155d6d9d2f"), "613", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1271), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1272), "Banco Pecúnia S.A." },
                    { new Guid("9808426a-61f1-11ec-9517-00155d6d9d2f"), "623", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1272), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1273), "Banco Panamericano S.A." },
                    { new Guid("9808426c-61f1-11ec-9517-00155d6d9d2f"), "626", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1274), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1274), "Banco Ficsa S.A." },
                    { new Guid("9808426f-61f1-11ec-9517-00155d6d9d2f"), "630", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1275), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1275), "Banco Intercap S.A." },
                    { new Guid("98084271-61f1-11ec-9517-00155d6d9d2f"), "633", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1276), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1276), "Banco Rendimento S.A." },
                    { new Guid("98084273-61f1-11ec-9517-00155d6d9d2f"), "634", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1277), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1278), "Banco Triângulo S.A." },
                    { new Guid("98084276-61f1-11ec-9517-00155d6d9d2f"), "637", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1279), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1279), "Banco Sofisa S.A." },
                    { new Guid("98084278-61f1-11ec-9517-00155d6d9d2f"), "638", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1280), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1281), "Banco Prosper S.A." },
                    { new Guid("9808427b-61f1-11ec-9517-00155d6d9d2f"), "641", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1281), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1282), "Banco Alvorada S.A." },
                    { new Guid("9808427d-61f1-11ec-9517-00155d6d9d2f"), "643", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1282), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1283), "Banco Pine S.A." },
                    { new Guid("9808427f-61f1-11ec-9517-00155d6d9d2f"), "652", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1284), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1285), "Itaú Unibanco Holding S.A." },
                    { new Guid("98084282-61f1-11ec-9517-00155d6d9d2f"), "653", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1285), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1286), "Banco Indusval S.A." },
                    { new Guid("98084285-61f1-11ec-9517-00155d6d9d2f"), "654", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1286), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1287), "Banco A.J.Renner S.A." }
                });

            migrationBuilder.InsertData(
                schema: "fin",
                table: "Banks",
                columns: new[] { "Id", "Code", "Creation", "IsDeleted", "LastUpdate", "Name" },
                values: new object[,]
                {
                    { new Guid("98084288-61f1-11ec-9517-00155d6d9d2f"), "655", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1288), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1288), "Banco Votorantim S.A." },
                    { new Guid("9808428a-61f1-11ec-9517-00155d6d9d2f"), "707", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1289), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1289), "Banco Daycoval S.A." },
                    { new Guid("9808428d-61f1-11ec-9517-00155d6d9d2f"), "719", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1290), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1290), "Banif-Banco Internacional do Funchal (Brasil)S.A." },
                    { new Guid("9808428f-61f1-11ec-9517-00155d6d9d2f"), "721", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1291), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1291), "Banco Credibel S.A." },
                    { new Guid("98084291-61f1-11ec-9517-00155d6d9d2f"), "724", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1292), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1292), "Banco Porto Seguro S.A." },
                    { new Guid("98084294-61f1-11ec-9517-00155d6d9d2f"), "734", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1293), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1294), "Banco Gerdau S.A." },
                    { new Guid("98084296-61f1-11ec-9517-00155d6d9d2f"), "735", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1294), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1295), "Banco Pottencial S.A." },
                    { new Guid("98084299-61f1-11ec-9517-00155d6d9d2f"), "738", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1296), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1296), "Banco Morada S.A." },
                    { new Guid("9808429b-61f1-11ec-9517-00155d6d9d2f"), "739", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1297), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1297), "Banco BGN S.A." },
                    { new Guid("9808429f-61f1-11ec-9517-00155d6d9d2f"), "740", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1298), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1298), "Banco Barclays S.A." },
                    { new Guid("980842a1-61f1-11ec-9517-00155d6d9d2f"), "741", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1299), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1299), "Banco Ribeirão Preto S.A." },
                    { new Guid("980842a3-61f1-11ec-9517-00155d6d9d2f"), "743", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1300), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1301), "Banco Semear S.A." },
                    { new Guid("980842a6-61f1-11ec-9517-00155d6d9d2f"), "744", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1301), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1302), "BankBoston N.A." },
                    { new Guid("980842a8-61f1-11ec-9517-00155d6d9d2f"), "745", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1302), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1303), "Banco Citibank S.A." },
                    { new Guid("980842ab-61f1-11ec-9517-00155d6d9d2f"), "746", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1304), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1304), "Banco Modal S.A." },
                    { new Guid("980842ae-61f1-11ec-9517-00155d6d9d2f"), "747", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1305), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1305), "Banco Rabobank International Brasil S.A." },
                    { new Guid("980842b1-61f1-11ec-9517-00155d6d9d2f"), "748", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1306), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1306), "Banco Cooperativo Sicredi S.A." },
                    { new Guid("980842b3-61f1-11ec-9517-00155d6d9d2f"), "749", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1307), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1308), "Banco Simples S.A." },
                    { new Guid("980842b6-61f1-11ec-9517-00155d6d9d2f"), "751", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1308), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1309), "Dresdner Bank Brasil S.A. – Banco Múltiplo" },
                    { new Guid("980842b8-61f1-11ec-9517-00155d6d9d2f"), "752", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1309), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1310), "Banco BNP Paribas Brasil S.A." },
                    { new Guid("980842bb-61f1-11ec-9517-00155d6d9d2f"), "753", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1311), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1311), "NBC Bank Brasil S.A. – Banco Múltiplo" },
                    { new Guid("980842c3-61f1-11ec-9517-00155d6d9d2f"), "755", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1312), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1312), "Bank of America Merrill Lynch Banco Múltiplo S.A." },
                    { new Guid("980842c7-61f1-11ec-9517-00155d6d9d2f"), "756", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1313), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1313), "Banco Cooperativo do Brasil S.A. – BANCOOB" },
                    { new Guid("980842ca-61f1-11ec-9517-00155d6d9d2f"), "757", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1314), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1314), "Banco KEB do Brasil S.A." },
                    { new Guid("980842cd-61f1-11ec-9517-00155d6d9d2f"), "M10", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1315), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1316), "Banco Moneo S.A." },
                    { new Guid("980842d0-61f1-11ec-9517-00155d6d9d2f"), "M11", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1316), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1317), "Banco IBM S.A." },
                    { new Guid("980842d3-61f1-11ec-9517-00155d6d9d2f"), "M20", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1318), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1318), "Banco Toyota do Brasil S.A." },
                    { new Guid("980842d6-61f1-11ec-9517-00155d6d9d2f"), "M21", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1319), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1319), "Banco Daimlerchrysler S.A." },
                    { new Guid("980842da-61f1-11ec-9517-00155d6d9d2f"), "M03", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1320), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1320), "Banco Fiat S.A." },
                    { new Guid("980842dd-61f1-11ec-9517-00155d6d9d2f"), "M12", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1321), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1321), "Banco Maxinvest S.A." },
                    { new Guid("980842df-61f1-11ec-9517-00155d6d9d2f"), "M22", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1322), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1322), "Banco Honda S.A." },
                    { new Guid("980842e2-61f1-11ec-9517-00155d6d9d2f"), "M13", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1323), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1324), "Banco Tricury S.A." },
                    { new Guid("980842e4-61f1-11ec-9517-00155d6d9d2f"), "M14", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1324), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1325), "Banco Volkswagen S.A." },
                    { new Guid("980842e7-61f1-11ec-9517-00155d6d9d2f"), "M23", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1325), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1326), "Banco Volvo (Brasil) S.A." },
                    { new Guid("980842ea-61f1-11ec-9517-00155d6d9d2f"), "M15", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1327), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1327), "Banco BRJ S.A." },
                    { new Guid("980842ed-61f1-11ec-9517-00155d6d9d2f"), "M06", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1328), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1328), "Banco de Lage Landen Brasil S.A." },
                    { new Guid("980842f0-61f1-11ec-9517-00155d6d9d2f"), "M24", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1329), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1329), "Banco PSA Finance Brasil S.A." },
                    { new Guid("980842f3-61f1-11ec-9517-00155d6d9d2f"), "M07", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1330), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1331), "Banco GMAC S.A." },
                    { new Guid("980842f5-61f1-11ec-9517-00155d6d9d2f"), "M16", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1331), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1332), "Banco Rodobens S.A." },
                    { new Guid("980842f8-61f1-11ec-9517-00155d6d9d2f"), "M08", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1333), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1333), "Banco Citicard S.A." },
                    { new Guid("980842fa-61f1-11ec-9517-00155d6d9d2f"), "M17", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1334), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1334), "Banco Ourinvest S.A." },
                    { new Guid("980842fd-61f1-11ec-9517-00155d6d9d2f"), "M18", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1335), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1335), "Banco Ford S.A." }
                });

            migrationBuilder.InsertData(
                schema: "fin",
                table: "Banks",
                columns: new[] { "Id", "Code", "Creation", "IsDeleted", "LastUpdate", "Name" },
                values: new object[] { new Guid("98084300-61f1-11ec-9517-00155d6d9d2f"), "M09", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1336), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1336), "Banco Itaucred Financiamentos S.A." });

            migrationBuilder.InsertData(
                schema: "fin",
                table: "Banks",
                columns: new[] { "Id", "Code", "Creation", "IsDeleted", "LastUpdate", "Name" },
                values: new object[] { new Guid("98084303-61f1-11ec-9517-00155d6d9d2f"), "M19", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1337), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1338), "Banco CNH Capital S.A." });

            migrationBuilder.InsertData(
                schema: "fin",
                table: "Banks",
                columns: new[] { "Id", "Code", "Creation", "IsDeleted", "LastUpdate", "Name" },
                values: new object[] { new Guid("98084306-61f1-11ec-9517-00155d6d9d2f"), "M19", new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1338), false, new DateTime(2021, 12, 20, 21, 7, 40, 956, DateTimeKind.Local).AddTicks(1339), "Banco CNH Capital S.A." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084106-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084138-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808413f-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084143-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084146-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084149-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808414b-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808414e-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084151-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084153-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084156-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808415a-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808415d-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808415f-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084162-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084165-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084168-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808416b-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808416e-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084171-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084175-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084178-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808417b-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808417d-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084180-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084182-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084185-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084187-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808418a-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808418c-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808418e-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084191-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084193-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084195-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084197-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084199-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808419c-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808419f-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841a1-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841a3-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841a6-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841a8-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841ab-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841ae-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841b1-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841b3-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841b5-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841b8-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841ba-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841bc-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841bf-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841c1-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841c4-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841c6-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841c9-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841cb-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841ce-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841d0-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841d3-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841d8-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841da-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841dd-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841e0-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841e3-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841e5-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841e8-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841ea-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841ed-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841f0-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841f3-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841f6-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841f9-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841fc-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980841ff-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084202-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084205-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084207-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808420a-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808420d-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808420f-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084212-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084214-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084216-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084219-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808421b-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808421d-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084220-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084222-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084224-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084227-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084229-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808422b-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808422e-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084230-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084232-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084235-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084238-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808423b-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808423d-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084240-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084243-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084245-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084248-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808424b-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808424d-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084250-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084252-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084256-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084259-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808425c-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084260-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084262-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084265-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084268-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808426a-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808426c-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808426f-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084271-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084273-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084276-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084278-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808427b-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808427d-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808427f-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084282-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084285-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084288-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808428a-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808428d-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808428f-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084291-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084294-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084296-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084299-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808429b-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9808429f-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842a1-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842a3-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842a6-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842a8-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842ab-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842ae-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842b1-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842b3-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842b6-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842b8-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842bb-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842c3-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842c7-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842ca-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842cd-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842d0-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842d3-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842d6-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842da-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842dd-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842df-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842e2-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842e4-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842e7-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842ea-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842ed-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842f0-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842f3-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842f5-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842f8-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842fa-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("980842fd-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084300-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084303-61f1-11ec-9517-00155d6d9d2f"));

            migrationBuilder.DeleteData(
                schema: "fin",
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("98084306-61f1-11ec-9517-00155d6d9d2f"));
        }
    }
}
