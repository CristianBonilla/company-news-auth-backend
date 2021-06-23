using System.Collections.Generic;

namespace Company.Domain
{
    public class Permissions : IPermissions
    {
        public ICollection<PermissionEntity> CanRoles { get; set; } = new HashSet<PermissionEntity>();
        public ICollection<PermissionEntity> CanUsers { get; set; } = new HashSet<PermissionEntity>();
        public ICollection<PermissionEntity> CanNews { get; set; } = new HashSet<PermissionEntity>();
    }
}
