using System;

namespace Company.Domain
{
    abstract class DefaultDataByUserRole
    {
        protected static NewsPermissionCollection News => new();
        protected static RolePermissionCollection Roles => new();
        protected static UserPermissionCollection Users => new();

        protected static (RoleEntity Role, Guid[] PermissionIDs) VisitorUser => (
            new()
            {
                Id = new Guid("590cb67a-5177-4bda-86e4-e5b80ac333c9"),
                Name = nameof(VisitorUser),
                DisplayName = "Visitante"
            },
            new[] { News[NewsPermissionTypes.ALL].Value });
        protected static (RoleEntity Role, Guid[] PermissionIDs) AssistantUser => (
            new()
            {
                Id = new Guid("f7b2beba-7445-463d-8978-0b3b3940390c"),
                Name = nameof(AssistantUser),
                DisplayName = "Asistente"
            },
            new[]
            {
                Roles[RolePermissionTypes.GetRoles].Value,
                Roles[RolePermissionTypes.GetRoleById].Value,
                Users[UserPermissionTypes.GetUsers].Value,
                Users[UserPermissionTypes.GetUserById].Value,
                News[NewsPermissionTypes.ALL].Value
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
                Roles[RolePermissionTypes.GetRoles].Value,
                Roles[RolePermissionTypes.GetRoleById].Value,
                Users[UserPermissionTypes.GetUsers].Value,
                Users[UserPermissionTypes.GetUserById].Value,
                Users[UserPermissionTypes.EditUser].Value,
                News[NewsPermissionTypes.ALL].Value
            });
        protected static (RoleEntity Role, Guid[] PermissionIDs) AdminUser => (
            new()
            {
                Id = new Guid("c651f92d-d9a1-45e8-9d04-3bb184da7a96"),
                Name = nameof(AdminUser),
                DisplayName = "Administrador"
            },
            new[]
            {
                Roles[RolePermissionTypes.ALL].Value,
                Users[UserPermissionTypes.ALL].Value,
                News[NewsPermissionTypes.ALL].Value
            });
    }
}
