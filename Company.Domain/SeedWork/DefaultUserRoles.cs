using System;

namespace Company.Domain
{
    public class DefaultUserRoles
    {
        public static (Guid, string, PermissionEntity[]) AdminUser { get; } = (
            new Guid("c651f92d-d9a1-45e8-9d04-3bb184da7a96"),
            nameof(AdminUser),
            new PermissionEntity[]
            {
                Roles.ALL,
                Users.ALL,
                News.ALL
            });
        public static (Guid, string, PermissionEntity[]) VisitorUser { get; } = (
            new Guid("590cb67a-5177-4bda-86e4-e5b80ac333c9"),
            nameof(VisitorUser),
            new PermissionEntity[]
            {
                News.ALL
            });
        public static (Guid, string, PermissionEntity[]) AssistantUser { get; } = (
            new Guid("f7b2beba-7445-463d-8978-0b3b3940390c"),
            nameof(AssistantUser),
            new PermissionEntity[]
            {
                Roles.GetRoles,
                Roles.GetRoleById,
                Users.GetUsers,
                Users.GetUserById,
                News.ALL
            });
        public static (Guid, string, PermissionEntity[]) EditorUser { get; } = (
            new Guid("3cb57f96-7092-4842-a3a4-5e8302f6618d"),
            nameof(EditorUser),
            new PermissionEntity[]
            {
                Roles.GetRoles,
                Roles.GetRoleById,
                Users.GetUsers,
                Users.GetUserById,
                Users.EditUser,
                News.ALL
            });
    }
}
