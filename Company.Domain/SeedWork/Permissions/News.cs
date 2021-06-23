using System;

namespace Company.Domain
{
    public class NewsPermission : PermissionEntity
    {
        public new string Type { get; } = nameof(IPermissions.CanNews);
    }

    public class News
    {
        public static NewsPermission ALL { get; } = new()
        {
            Id = new Guid("4f39c31e-ca99-4782-b585-ae847185a292"),
            Name = nameof(ALL),
            DisplayName = "Todos",
            Order = 1
        };
        public static NewsPermission GetNews { get; } = new()
        {
            Id = new Guid("f79b85e6-0911-43e1-b68f-49fa74a52518"),
            Order = 2,
            Name = nameof(GetNews),
            DisplayName = "Listar Noticias"
        };
        public static NewsPermission GetNewsById { get; } = new()
        {
            Id = new Guid("6d05ba82-9e0c-46ea-9e90-b268bca31885"),
            Order = 3,
            Name = nameof(GetNewsById),
            DisplayName = "Detalle de Noticias"
        };
    }
}
