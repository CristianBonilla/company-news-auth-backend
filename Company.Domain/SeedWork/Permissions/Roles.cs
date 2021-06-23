using System;

namespace Company.Domain
{
    public class RolesPermission : PermissionEntity
    {
        const string CanRoles = nameof(CanRoles);
        public new string Type { get; } = CanRoles;
    }

    public class Roles
    {
        public static RolesPermission ALL { get; } = new()
        {
            Id = new Guid("e5472dd9-f0c1-4233-be69-cb59425a8407"),
            Name = nameof(ALL),
            DisplayName = "Todos",
            Order = 1
        };
        public static RolesPermission GetRoles { get; } = new()
        {
            Id = new Guid("69778186-75fd-445d-9993-b9f9b35d78bc"),
            Name = nameof(GetRoles),
            DisplayName = "Listar Roles",
            Order = 2
        };
        public static RolesPermission GetRoleById { get; } = new()
        {
            Id = new Guid("bfaa9995-bfa4-4c5b-b4dc-754be406cb18"),
            Name = nameof(GetRoleById),
            DisplayName = "Detalle del Rol",
            Order = 3
        };
        public static RolesPermission GetPermissions { get; } = new()
        {
            Id = new Guid("6a2493a7-27f7-414f-9e8c-47077feafa82"),
            Name = nameof(GetPermissions),
            DisplayName = "Listar Permisos",
            Order = 4
        };
        public static RolesPermission GetPermissionsByRole { get; } = new()
        {
            Id = new Guid("71fea3d3-2d23-4971-97c1-23cec13242ba"),
            Name = nameof(GetPermissionsByRole),
            DisplayName = "Listar Permisos por Rol",
            Order = 5
        };
    }
}
