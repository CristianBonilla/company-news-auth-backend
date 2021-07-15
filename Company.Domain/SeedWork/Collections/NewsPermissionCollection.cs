using System;
using System.Linq;

namespace Company.Domain
{
    class NewsPermissionCollection
    {
        public NewsPermission[] List { get; } = 
        {
            new()
            {
                Id = new Guid("4f39c31e-ca99-4782-b585-ae847185a292"),
                Name = nameof(NewsPermissionTypes.ALL),
                DisplayName = "Todo",
                Order = 1
            },
            new()
            {
                Id = new Guid("f79b85e6-0911-43e1-b68f-49fa74a52518"),
                Name = nameof(NewsPermissionTypes.GetNews),
                DisplayName = "Listar Noticias",
                Order = 2
            },
            new()
            {
                Id = new Guid("6d05ba82-9e0c-46ea-9e90-b268bca31885"),
                Name = nameof(NewsPermissionTypes.GetNewsById),
                DisplayName = "Detalle de Noticias",
                Order = 3
            }
        };

        public Guid this[NewsPermissionTypes type] => List.Single(permission => permission.Name == Enum.GetName(type)).Id;
    }
}
