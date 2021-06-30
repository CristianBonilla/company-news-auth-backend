namespace Company.Domain
{
    public class NewsPermission : PermissionEntity
    {
        public new string Type { get; } = DefaultPermissions.CanNews;
    }
}
