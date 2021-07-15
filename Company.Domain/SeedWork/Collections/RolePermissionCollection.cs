using System;
using System.Linq;

namespace Company.Domain
{
    class RolePermissionCollection
    {
        public RolesPermission[] List { get; } =
        {
            new()
            {
                Id = new Guid("e5472dd9-f0c1-4233-be69-cb59425a8407"),
                Name = nameof(RolePermissionTypes.ALL),
                DisplayName = "Todo",
                Order = 1
            },
            new()
            {
                Id = new Guid("69778186-75fd-445d-9993-b9f9b35d78bc"),
                Name = nameof(RolePermissionTypes.GetRoles),
                DisplayName = "Listar Roles",
                Order = 2
            },
            new()
            {
                Id = new Guid("bfaa9995-bfa4-4c5b-b4dc-754be406cb18"),
                Name = nameof(RolePermissionTypes.GetRoleById),
                DisplayName = "Detalle del Rol",
                Order = 3
            },
            new()
            {
                Id = new Guid("6a2493a7-27f7-414f-9e8c-47077feafa82"),
                Name = nameof(RolePermissionTypes.GetPermissions),
                DisplayName = "Listar Permisos",
                Order = 4
            },
            new()
            {
                Id = new Guid("71fea3d3-2d23-4971-97c1-23cec13242ba"),
                Name = nameof(RolePermissionTypes.GetPermissionsByRole),
                DisplayName = "Listar Permisos por Rol",
                Order = 5
            }
        };

        public Guid this[RolePermissionTypes type] => List.Single(permission => permission.Name == Enum.GetName(type)).Id;
    }
}
