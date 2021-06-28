using System.Collections.Generic;

namespace Company.API
{
    public class AuthResult
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public UserResponse User { get; set; }
        public RoleResponse Role { get; set; }
        public IEnumerable<PermissionResponse> Permissions { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
