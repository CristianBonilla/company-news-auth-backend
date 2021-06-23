using System;

namespace Company.Domain
{
    public class PermissionEntity
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
