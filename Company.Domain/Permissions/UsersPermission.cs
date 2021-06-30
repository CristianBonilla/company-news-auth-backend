namespace Company.Domain
{
    public class UsersPermission : PermissionEntity
    {
        public new string Type { get; } = DefaultPermissions.CanUsers;
    }
}
