using System;

namespace Company.Domain
{
    public class RolesPermission : PermissionEntity
    {
        public new string Type { get; } = Enum.GetName(DefaultPermissionTypes.CanRoles);
    }
}
