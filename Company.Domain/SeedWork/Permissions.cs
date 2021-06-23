using System.Collections.Generic;

namespace Company.Domain
{
    public class Permissions
    {
        public ICollection<RolePermissions> CanRoles { get; set; }
        public ICollection<UserPermissions> CanUsers { get; set; }
        public ICollection<NewsPermissions> CanNews { get; set; }

        public Permissions()
        {
            CanRoles = new HashSet<RolePermissions>();
            CanUsers = new HashSet<UserPermissions>();
            CanNews = new HashSet<NewsPermissions>();
        }
    }
}
