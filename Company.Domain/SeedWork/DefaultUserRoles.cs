namespace Company.Domain
{
    public class DefaultUserRoles
    {
        public static (string, Permissions) AdminUser { get; } = (nameof(AdminUser),
            new()
            {
                CanRoles = new[] { Roles.ALL },
                CanUsers = new[] { Users.ALL },
                CanNews = new[] { News.ALL }
            });
        public static (string, Permissions) VisitorUser { get; } = (nameof(VisitorUser),
            new()
            {
                CanNews = new[] { News.ALL }
            });
        public static (string, Permissions) AssistantUser { get; } = (nameof(AssistantUser),
            new()
            {
                CanRoles = new[]
                {
                    Roles.GetRoles,
                    Roles.GetRoleById
                },
                CanUsers = new[]
                {
                    Users.GetUsers,
                    Users.GetUserById
                },
                CanNews = new[] { News.ALL }
            });
        public static (string, Permissions) EditorUser { get; } = (nameof(EditorUser),
            new()
            {
                CanRoles = new[]
                {
                    Roles.GetRoles,
                    Roles.GetRoleById
                },
                CanUsers = new[]
                {
                    Users.GetUsers,
                    Users.GetUserById,
                    Users.EditUser
                },
                CanNews = new[] { News.ALL }
            });
    }
}
