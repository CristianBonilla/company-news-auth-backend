using System.Collections.Generic;

namespace Company.API
{
    public class AuthSuccessResponse
    {
        public string Token { get; set; }
        public UserResponse User { get; set; }
        public RoleResponse Role { get; set; }
        public IEnumerable<PermissionResponse> Permissions { get; set; }
    }
}
