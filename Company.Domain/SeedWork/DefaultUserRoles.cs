namespace Company.Domain
{
    public class DefaultUserRoles
    {
        public static (string, Permissions) AdminUser
        {
            get => (nameof(AdminUser), new()
            {
                CanRoles = new[] { RolePermissions.ALL },
                CanUsers = new[] { UserPermissions.ALL },
                CanNews = new[] { NewsPermissions.ALL }
            });
        }
        public static (string, Permissions) VisitorUser
        {
            get => (nameof(VisitorUser), new()
            {
                CanNews = new[] { NewsPermissions.ALL }
            });
        }
        public static (string, Permissions) AssistantUser
        {
            get => (nameof(AssistantUser), new()
            {
                CanRoles = new[]
                {
                    RolePermissions.GetRoles,
                    RolePermissions.GetRoleById
                },
                CanUsers = new[]
                {
                    UserPermissions.GetUsers,
                    UserPermissions.GetUserById
                },
                CanNews = new[] { NewsPermissions.ALL }
            });
        }
        public static (string, Permissions) EditorUser
        {
            get => (nameof(EditorUser), new()
            {
                CanRoles = new[]
                {
                    RolePermissions.GetRoles,
                    RolePermissions.GetRoleById
                },
                CanUsers = new[]
                {
                    UserPermissions.GetUsers,
                    UserPermissions.GetUserById,
                    UserPermissions.EditUser
                },
                CanNews = new[] { NewsPermissions.ALL }
            });
        }
    }
}
