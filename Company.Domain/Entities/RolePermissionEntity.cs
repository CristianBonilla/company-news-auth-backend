using System;

namespace Company.Domain
{
    public class RolePermissionEntity
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
        public RoleEntity Role { get; set; }
        public PermissionEntity Permission { get; set; }
    }
}
