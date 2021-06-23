using System;

namespace Company.Domain
{
    public class RolesPermission : PermissionEntity
    {
        public new string Type { get; } = nameof(IPermissions.CanRoles);
    }

    public class Roles
    {
        public static RolesPermission ALL { get; } = new()
        {
            Id = new Guid("e5472dd9-f0c1-4233-be69-cb59425a8407"),
            Order = 1,
            Name = nameof(ALL),
            DisplayName = "Todos"
        };
        public static RolesPermission GetRoles { get; } = new()
        {
            Id = new Guid("69778186-75fd-445d-9993-b9f9b35d78bc"),
            Order = 2,
            Name = nameof(GetRoles),
            DisplayName = "Listar Roles"
        };
        public static RolesPermission GetRoleById { get; } = new()
        {
            Id = new Guid("bfaa9995-bfa4-4c5b-b4dc-754be406cb18"),
            Order = 3,
            Name = nameof(GetRoleById),
            DisplayName = "Detalle del Rol"
        };
        public static RolesPermission GetPermissions { get; } = new()
        {
            Id = new Guid("6a2493a7-27f7-414f-9e8c-47077feafa82"),
            Order = 4,
            Name = nameof(GetPermissions),
            DisplayName = "Listar Permisos"
        };
        public static RolesPermission GetPermissionsByRole { get; } = new()
        {
            Id = new Guid("71fea3d3-2d23-4971-97c1-23cec13242ba"),
            Order = 5,
            Name = nameof(GetPermissionsByRole),
            DisplayName = "Listar Permisos por Rol"
        };
    }
}
