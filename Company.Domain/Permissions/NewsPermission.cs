namespace Company.Domain
{
    public class NewsPermission : PermissionEntity
    {
        public new string Type { get; } = PermissionTypes.CanNews;
    }
}
