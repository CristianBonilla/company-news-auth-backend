using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Domain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "News",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Type = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    DisplayName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    DisplayName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                schema: "dbo",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "dbo",
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermission_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentificationNumber = table.Column<long>(type: "bigint", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "News",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("47d0fc63-ccd3-48c6-825c-496a56db4adb"), "Figuran ejecutivas de D1, Cencosud, Cerrejón y Comparta. Tres de ellas asumieron en los últimos dos años", "Solo hay 4 mujeres en los CEO de las 100 empresas más grandes" },
                    { new Guid("056cff93-297c-4145-8035-ded5cbc32c61"), "El préstamo, incluye recursos para la construcción del Parque Solar San Fernando (Meta) por cerca de US$35 millones", "Crédito de Scotiabank Colpatria por US$100 millones a AES Colombia" },
                    { new Guid("9e77ccaf-98f6-426f-9f95-df113d985235"), "Se trata de Shopify, que brindará soporte y apoyo a comerciantes que no usan directamente su plataforma", "Google y Facebook firman asociación con empresa de pago en línea" },
                    { new Guid("b0ec35d4-9a19-4e6d-8cd2-817b968c2bb8"), "Los delincuentes envían cartas a las viviendas de sus víctimas haciéndose pasar por la compañía Ledger. En el documento piden a las personas compartir su información en un nuevo dispositivo para supuestamente mantener los datos seguros", "Bitcóin: hackers tienen nuevo método para robar criptomonedas" },
                    { new Guid("a6e7bad2-ac9c-407a-a0bb-2d32b51e794a"), "Habi, la startup con sede en Colombia, anunció este miércoles que recaudó 100 millones de dólares en la ronda de financiación de serie B por parte de SoftBank Latin American Fund, junto con inversores de Inspired Capital, Tiger Global, Homebrew y 8VC", "'Startup' Habi recauda 100 millones de dólares en ronda de inversión" },
                    { new Guid("c2cca9ea-b8c1-4abf-b70c-e47be5f06f92"), "Después de un año de ausencia por la pandemia, finalmente el Electronic Entertainment Expo (E3) volvió con varias novedades para los amantes de los videojuegos, aunque no cumplió todas las expectativas en materia de los anuncios que se tenían presupuestados", "E3: los mejores anuncios que dejó el evento en su edición virtual" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Permission",
                columns: new[] { "Id", "DisplayName", "Name", "Order", "Type" },
                values: new object[,]
                {
                    { new Guid("73eadeb6-bc84-4d98-ab6e-04f85e057db7"), "Crear Usuario", "AddUser", 4, "CanUsers" },
                    { new Guid("cb5095c0-02cd-4b10-8666-09eaafeda595"), "Detalle del Usuario", "GetUserById", 3, "CanUsers" },
                    { new Guid("f6176536-ac08-4607-b003-11caa3cc5e31"), "Listar Usuarios", "GetUsers", 2, "CanUsers" },
                    { new Guid("d3683aa7-defb-48ea-8459-b17a34a0c363"), "Todos", "ALL", 1, "CanUsers" },
                    { new Guid("71fea3d3-2d23-4971-97c1-23cec13242ba"), "Listar Permisos por Rol", "GetPermissionsByRole", 5, "CanRoles" },
                    { new Guid("6a2493a7-27f7-414f-9e8c-47077feafa82"), "Listar Permisos", "GetPermissions", 4, "CanRoles" },
                    { new Guid("bfaa9995-bfa4-4c5b-b4dc-754be406cb18"), "Detalle del Rol", "GetRoleById", 3, "CanRoles" },
                    { new Guid("69778186-75fd-445d-9993-b9f9b35d78bc"), "Listar Roles", "GetRoles", 2, "CanRoles" },
                    { new Guid("a984910b-6ecc-43e0-82d5-e9c9b0c78d03"), "Eliminar Usuario", "RemoveUser", 6, "CanUsers" },
                    { new Guid("942d6f21-a7f7-43cd-9588-23657911fea2"), "Editar Usuario", "EditUser", 5, "CanUsers" },
                    { new Guid("6d05ba82-9e0c-46ea-9e90-b268bca31885"), "Detalle de Noticias", "GetNewsById", 3, "CanNews" },
                    { new Guid("f79b85e6-0911-43e1-b68f-49fa74a52518"), "Listar Noticias", "GetNews", 2, "CanNews" },
                    { new Guid("4f39c31e-ca99-4782-b585-ae847185a292"), "Todos", "ALL", 1, "CanNews" },
                    { new Guid("e5472dd9-f0c1-4233-be69-cb59425a8407"), "Todos", "ALL", 1, "CanRoles" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Role",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[,]
                {
                    { new Guid("c651f92d-d9a1-45e8-9d04-3bb184da7a96"), "Administrador", "AdminUser" },
                    { new Guid("f7b2beba-7445-463d-8978-0b3b3940390c"), "Asistente", "AssistantUser" },
                    { new Guid("590cb67a-5177-4bda-86e4-e5b80ac333c9"), "Visitante", "VisitorUser" },
                    { new Guid("3cb57f96-7092-4842-a3a4-5e8302f6618d"), "Editor", "EditorUser" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("4f39c31e-ca99-4782-b585-ae847185a292"), new Guid("590cb67a-5177-4bda-86e4-e5b80ac333c9") },
                    { new Guid("4f39c31e-ca99-4782-b585-ae847185a292"), new Guid("f7b2beba-7445-463d-8978-0b3b3940390c") },
                    { new Guid("4f39c31e-ca99-4782-b585-ae847185a292"), new Guid("3cb57f96-7092-4842-a3a4-5e8302f6618d") },
                    { new Guid("4f39c31e-ca99-4782-b585-ae847185a292"), new Guid("c651f92d-d9a1-45e8-9d04-3bb184da7a96") },
                    { new Guid("e5472dd9-f0c1-4233-be69-cb59425a8407"), new Guid("c651f92d-d9a1-45e8-9d04-3bb184da7a96") },
                    { new Guid("69778186-75fd-445d-9993-b9f9b35d78bc"), new Guid("f7b2beba-7445-463d-8978-0b3b3940390c") },
                    { new Guid("69778186-75fd-445d-9993-b9f9b35d78bc"), new Guid("3cb57f96-7092-4842-a3a4-5e8302f6618d") },
                    { new Guid("bfaa9995-bfa4-4c5b-b4dc-754be406cb18"), new Guid("f7b2beba-7445-463d-8978-0b3b3940390c") },
                    { new Guid("bfaa9995-bfa4-4c5b-b4dc-754be406cb18"), new Guid("3cb57f96-7092-4842-a3a4-5e8302f6618d") },
                    { new Guid("d3683aa7-defb-48ea-8459-b17a34a0c363"), new Guid("c651f92d-d9a1-45e8-9d04-3bb184da7a96") },
                    { new Guid("f6176536-ac08-4607-b003-11caa3cc5e31"), new Guid("f7b2beba-7445-463d-8978-0b3b3940390c") },
                    { new Guid("f6176536-ac08-4607-b003-11caa3cc5e31"), new Guid("3cb57f96-7092-4842-a3a4-5e8302f6618d") },
                    { new Guid("cb5095c0-02cd-4b10-8666-09eaafeda595"), new Guid("f7b2beba-7445-463d-8978-0b3b3940390c") },
                    { new Guid("cb5095c0-02cd-4b10-8666-09eaafeda595"), new Guid("3cb57f96-7092-4842-a3a4-5e8302f6618d") },
                    { new Guid("942d6f21-a7f7-43cd-9588-23657911fea2"), new Guid("3cb57f96-7092-4842-a3a4-5e8302f6618d") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_Type_Name",
                schema: "dbo",
                table: "Permission",
                columns: new[] { "Type", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_Name",
                schema: "dbo",
                table: "Role",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionId",
                schema: "dbo",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdentificationNumber_Username_Email",
                schema: "dbo",
                table: "User",
                columns: new[] { "IdentificationNumber", "Username", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                schema: "dbo",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RolePermission",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "dbo");
        }
    }
}
