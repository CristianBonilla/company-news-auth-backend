using System;

namespace Company.Domain
{
    public abstract class PermissionEntity
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int Order { get; set; }
    }
}
