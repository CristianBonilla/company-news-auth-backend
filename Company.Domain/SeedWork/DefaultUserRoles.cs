using System;

namespace Company.Domain
{
    public class DefaultUserRoles
    {
        public static (RoleEntity Role, PermissionEntity[] Permissions) AdminUser { get; } = (
            new()
            {
               Id = new Guid("c651f92d-d9a1-45e8-9d04-3bb184da7a96"),
               Name = nameof(AdminUser),
               DisplayName = "Administrador"
            },
            new PermissionEntity[]
            {
                Roles.ALL,
                Users.ALL,
                News.ALL
            });
        public static (RoleEntity Role, PermissionEntity[] Permissions) VisitorUser { get; } = (
            new()
            {
                Id = new Guid("590cb67a-5177-4bda-86e4-e5b80ac333c9"),
                Name = nameof(VisitorUser),
                DisplayName = "Visitante"
            },
            new[] { News.ALL });
        public static (RoleEntity Role, PermissionEntity[] Permissions) AssistantUser { get; } = (
            new()
            {
                Id = new Guid("f7b2beba-7445-463d-8978-0b3b3940390c"),
                Name = nameof(AssistantUser),
                DisplayName = "Asistente"
            },
            new PermissionEntity[]
            {
                Roles.GetRoles,
                Roles.GetRoleById,
                Users.GetUsers,
                Users.GetUserById,
                News.ALL
            });
        public static (RoleEntity Role, PermissionEntity[] Permissions) EditorUser { get; } = (
            new()
            {
                Id = new Guid("3cb57f96-7092-4842-a3a4-5e8302f6618d"),
                Name = nameof(EditorUser),
                DisplayName = "Editor"
            },
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
