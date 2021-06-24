using System;

namespace Company.Domain
{
    abstract class DefaultUserRoles
    {
        protected static NewsCollection News => new();
        protected static RolesCollection Roles => new();
        protected static UsersCollection Users => new();

        protected static (RoleEntity Role, Guid[] PermissionIDs) AdminUser => (
            new()
            {
               Id = new Guid("c651f92d-d9a1-45e8-9d04-3bb184da7a96"),
               Name = nameof(AdminUser),
               DisplayName = "Administrador"
            },
            new[]
            {
                Roles[RoleTypes.ALL].Value,
                Users[UserTypes.ALL].Value,
                News[NewsType.ALL].Value
            });
        protected static (RoleEntity Role, Guid[] PermissionIDs) VisitorUser => (
            new()
            {
                Id = new Guid("590cb67a-5177-4bda-86e4-e5b80ac333c9"),
                Name = nameof(VisitorUser),
                DisplayName = "Visitante"
            },
            new[] { News[NewsType.ALL].Value });
        protected static (RoleEntity Role, Guid[] PermissionIDs) AssistantUser => (
            new()
            {
                Id = new Guid("f7b2beba-7445-463d-8978-0b3b3940390c"),
                Name = nameof(AssistantUser),
                DisplayName = "Asistente"
            },
            new[]
            {
                Roles[RoleTypes.GetRoles].Value,
                Roles[RoleTypes.GetRoleById].Value,
                Users[UserTypes.GetUsers].Value,
                Users[UserTypes.GetUserById].Value,
                News[NewsType.ALL].Value
            });
        protected static (RoleEntity Role, Guid[] PermissionIDs) EditorUser => (
            new()
            {
                Id = new Guid("3cb57f96-7092-4842-a3a4-5e8302f6618d"),
                Name = nameof(EditorUser),
                DisplayName = "Editor"
            },
            new[]
            {
                Roles[RoleTypes.GetRoles].Value,
                Roles[RoleTypes.GetRoleById].Value,
                Users[UserTypes.GetUsers].Value,
                Users[UserTypes.GetUserById].Value,
                Users[UserTypes.EditUser].Value,
                News[NewsType.ALL].Value
            });
    }
}
