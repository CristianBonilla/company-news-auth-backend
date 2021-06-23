using System;

namespace Company.Domain
{
    public class News
    {
        public static PermissionEntity ALL { get; } = new()
        {
            Id = new Guid("4f39c31e-ca99-4782-b585-ae847185a292"),
            Order = 1,
            Name = nameof(ALL),
            DisplayName = "Todos"
        };
        public static PermissionEntity GetNews { get; } = new()
        {
            Id = new Guid("f79b85e6-0911-43e1-b68f-49fa74a52518"),
            Order = 2,
            Name = nameof(GetNews),
            DisplayName = "Listar Noticias"
        };
        public static PermissionEntity GetNewsById { get; } = new()
        {
            Id = new Guid("6d05ba82-9e0c-46ea-9e90-b268bca31885"),
            Order = 3,
            Name = nameof(GetNewsById),
            DisplayName = "Detalle de Noticias"
        };
    }
}
