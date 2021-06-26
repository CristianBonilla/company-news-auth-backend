using System;

namespace Company.API
{
    class PermissionResponse
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int Order { get; set; }
    }
}
