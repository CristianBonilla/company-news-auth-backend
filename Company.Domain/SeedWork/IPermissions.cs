using System.Collections.Generic;

namespace Company.Domain
{
    public interface IPermissions
    {
        ICollection<RolesPermission> CanRoles { get; set; }
        ICollection<UsersPermission> CanUsers { get; set; }
        ICollection<NewsPermission> CanNews { get; set; }
    }
}
