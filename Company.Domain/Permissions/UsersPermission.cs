using System;

namespace Company.Domain
{
    public class UsersPermission : PermissionEntity
    {
        public new string Type { get; } = Enum.GetName(DefaultPermissionTypes.CanUsers);
    }
}
