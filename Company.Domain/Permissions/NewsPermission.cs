using System;

namespace Company.Domain
{
    public class NewsPermission : PermissionEntity
    {
        public new string Type { get; } = Enum.GetName(DefaultPermissionTypes.CanNews);
    }
}
