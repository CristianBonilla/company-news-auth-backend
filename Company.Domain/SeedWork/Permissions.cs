using System.Collections.Generic;

namespace Company.Domain
{
    public class Permissions : IPermissions
    {
        public ICollection<RolesPermission> CanRoles { get; set; } = new HashSet<RolesPermission>();
        public ICollection<UsersPermission> CanUsers { get; set; } = new HashSet<UsersPermission>();
        public ICollection<NewsPermission> CanNews { get; set; } = new HashSet<NewsPermission>();
    }
}
