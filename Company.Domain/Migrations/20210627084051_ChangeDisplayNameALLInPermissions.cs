using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Domain.Migrations
{
    public partial class ChangeDisplayNameALLInPermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("0c42bc5e-9c6d-45c9-8bf6-ae3983da4dd4"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("5aad402e-a2f3-4103-83e1-097e4219a4f8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("6c58d694-e913-4b81-a74b-26d3795d48a1"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("cb7d7cd3-0510-4203-9176-2f6b3b937519"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("f0660d32-93f8-438b-80db-8df975641bc8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("f9b55d06-c802-4e39-b371-dbbf097ca9cb"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "News",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("3f1e5227-b380-4df1-bdd6-fd30c9ef6649"), "Figuran ejecutivas de D1, Cencosud, Cerrejón y Comparta. Tres de ellas asumieron en los últimos dos años", "Solo hay 4 mujeres en los CEO de las 100 empresas más grandes" },
                    { new Guid("eac51bda-51f6-4bd7-8cbd-33d75729c881"), "El préstamo, incluye recursos para la construcción del Parque Solar San Fernando (Meta) por cerca de US$35 millones", "Crédito de Scotiabank Colpatria por US$100 millones a AES Colombia" },
                    { new Guid("7647ea63-46b0-4c71-b9db-29f1c972eac7"), "Se trata de Shopify, que brindará soporte y apoyo a comerciantes que no usan directamente su plataforma", "Google y Facebook firman asociación con empresa de pago en línea" },
                    { new Guid("78451362-86fc-4662-9fd6-711b9565628e"), "Los delincuentes envían cartas a las viviendas de sus víctimas haciéndose pasar por la compañía Ledger. En el documento piden a las personas compartir su información en un nuevo dispositivo para supuestamente mantener los datos seguros", "Bitcóin: hackers tienen nuevo método para robar criptomonedas" },
                    { new Guid("c2c9f618-53a0-49ce-8e0f-b1366e659937"), "Habi, la startup con sede en Colombia, anunció este miércoles que recaudó 100 millones de dólares en la ronda de financiación de serie B por parte de SoftBank Latin American Fund, junto con inversores de Inspired Capital, Tiger Global, Homebrew y 8VC", "'Startup' Habi recauda 100 millones de dólares en ronda de inversión" },
                    { new Guid("fc634a41-70da-4d63-ad07-eea34b883fe8"), "Después de un año de ausencia por la pandemia, finalmente el Electronic Entertainment Expo (E3) volvió con varias novedades para los amantes de los videojuegos, aunque no cumplió todas las expectativas en materia de los anuncios que se tenían presupuestados", "E3: los mejores anuncios que dejó el evento en su edición virtual" }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("4f39c31e-ca99-4782-b585-ae847185a292"),
                column: "DisplayName",
                value: "Todo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("e5472dd9-f0c1-4233-be69-cb59425a8407"),
                column: "DisplayName",
                value: "Todo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("d3683aa7-defb-48ea-8459-b17a34a0c363"),
                column: "DisplayName",
                value: "Todo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("3f1e5227-b380-4df1-bdd6-fd30c9ef6649"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("7647ea63-46b0-4c71-b9db-29f1c972eac7"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("78451362-86fc-4662-9fd6-711b9565628e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("c2c9f618-53a0-49ce-8e0f-b1366e659937"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("eac51bda-51f6-4bd7-8cbd-33d75729c881"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "News",
                keyColumn: "Id",
                keyValue: new Guid("fc634a41-70da-4d63-ad07-eea34b883fe8"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "News",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("f0660d32-93f8-438b-80db-8df975641bc8"), "Figuran ejecutivas de D1, Cencosud, Cerrejón y Comparta. Tres de ellas asumieron en los últimos dos años", "Solo hay 4 mujeres en los CEO de las 100 empresas más grandes" },
                    { new Guid("cb7d7cd3-0510-4203-9176-2f6b3b937519"), "El préstamo, incluye recursos para la construcción del Parque Solar San Fernando (Meta) por cerca de US$35 millones", "Crédito de Scotiabank Colpatria por US$100 millones a AES Colombia" },
                    { new Guid("5aad402e-a2f3-4103-83e1-097e4219a4f8"), "Se trata de Shopify, que brindará soporte y apoyo a comerciantes que no usan directamente su plataforma", "Google y Facebook firman asociación con empresa de pago en línea" },
                    { new Guid("0c42bc5e-9c6d-45c9-8bf6-ae3983da4dd4"), "Los delincuentes envían cartas a las viviendas de sus víctimas haciéndose pasar por la compañía Ledger. En el documento piden a las personas compartir su información en un nuevo dispositivo para supuestamente mantener los datos seguros", "Bitcóin: hackers tienen nuevo método para robar criptomonedas" },
                    { new Guid("6c58d694-e913-4b81-a74b-26d3795d48a1"), "Habi, la startup con sede en Colombia, anunció este miércoles que recaudó 100 millones de dólares en la ronda de financiación de serie B por parte de SoftBank Latin American Fund, junto con inversores de Inspired Capital, Tiger Global, Homebrew y 8VC", "'Startup' Habi recauda 100 millones de dólares en ronda de inversión" },
                    { new Guid("f9b55d06-c802-4e39-b371-dbbf097ca9cb"), "Después de un año de ausencia por la pandemia, finalmente el Electronic Entertainment Expo (E3) volvió con varias novedades para los amantes de los videojuegos, aunque no cumplió todas las expectativas en materia de los anuncios que se tenían presupuestados", "E3: los mejores anuncios que dejó el evento en su edición virtual" }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("4f39c31e-ca99-4782-b585-ae847185a292"),
                column: "DisplayName",
                value: "Todos");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("e5472dd9-f0c1-4233-be69-cb59425a8407"),
                column: "DisplayName",
                value: "Todos");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("d3683aa7-defb-48ea-8459-b17a34a0c363"),
                column: "DisplayName",
                value: "Todos");
        }
    }
}
