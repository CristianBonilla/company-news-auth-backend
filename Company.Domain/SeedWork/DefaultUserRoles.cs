using System;

namespace Company.Domain
{
    public abstract class DefaultUserRoles
    {
        protected static NewsCollection News => new();
        protected static RolesCollection Roles => new();
        protected static UsersCollection Users => new();

        protected static (RoleEntity Role, PermissionEntity[] Permissions) AdminUser => (
            new()
            {
               Id = new Guid("c651f92d-d9a1-45e8-9d04-3bb184da7a96"),
               Name = nameof(AdminUser),
               DisplayName = "Administrador"
            },
            new PermissionEntity[]
            {
                Roles[RoleTypes.ALL],
                Users[UserTypes.ALL],
                News[NewsType.ALL]
            });
        protected static (RoleEntity Role, PermissionEntity[] Permissions) VisitorUser => (
            new()
            {
                Id = new Guid("590cb67a-5177-4bda-86e4-e5b80ac333c9"),
                Name = nameof(VisitorUser),
                DisplayName = "Visitante"
            },
            new[] { News[NewsType.ALL] });
        protected static (RoleEntity Role, PermissionEntity[] Permissions) AssistantUser => (
            new()
            {
                Id = new Guid("f7b2beba-7445-463d-8978-0b3b3940390c"),
                Name = nameof(AssistantUser),
                DisplayName = "Asistente"
            },
            new PermissionEntity[]
            {
                Roles[RoleTypes.GetRoles],
                Roles[RoleTypes.GetRoleById],
                Users[UserTypes.GetUsers],
                Users[UserTypes.GetUserById],
                News[NewsType.ALL]
            });
        protected static (RoleEntity Role, PermissionEntity[] Permissions) EditorUser => (
            new()
            {
                Id = new Guid("3cb57f96-7092-4842-a3a4-5e8302f6618d"),
                Name = nameof(EditorUser),
                DisplayName = "Editor"
            },
            new PermissionEntity[]
            {
                Roles[RoleTypes.GetRoles],
                Roles[RoleTypes.GetRoleById],
                Users[UserTypes.GetUsers],
                Users[UserTypes.GetUserById],
                Users[UserTypes.EditUser],
                News[NewsType.ALL]
            });
    }
}
