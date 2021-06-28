using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Domain.Migrations
{
    public partial class ChangeDisplayNameALLInPermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
