namespace Company.Domain
{
    public class RolesPermission : PermissionEntity
    {
        public new string Type { get; } = DefaultPermissions.CanRoles;
    }
}
