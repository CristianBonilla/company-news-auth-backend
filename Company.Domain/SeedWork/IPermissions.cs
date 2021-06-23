using System.Collections.Generic;

namespace Company.Domain
{
    public interface IPermissions
    {
        ICollection<PermissionEntity> CanRoles { get; set; }
        ICollection<PermissionEntity> CanUsers { get; set; }
        ICollection<PermissionEntity> CanNews { get; set; }
    }
}
