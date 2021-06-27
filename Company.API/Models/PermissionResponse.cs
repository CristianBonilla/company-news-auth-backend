using System;
using System.Collections.Generic;

namespace Company.API
{
    public class PermissionResponse
    {
        public string Type { get; set; }
        public IEnumerable<PermissionDetailResponse> Content { get; set; }
    }

    public class PermissionDetailResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int Order { get; set; }
    }
}
