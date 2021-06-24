using System;
using System.Linq;

namespace Company.Domain
{
    enum UserTypes
    {
        ALL,
        GetUsers,
        GetUserById,
        AddUser,
        EditUser,
        RemoveUser
    }

    class UsersCollection
    {
        public UsersPermission[] List { get; } =
        {
            new()
            {
                Id = new Guid("d3683aa7-defb-48ea-8459-b17a34a0c363"),
                Name = nameof(UserTypes.ALL),
                DisplayName = "Todos",
                Order = 1
            },
            new()
            {
                Id = new Guid("f6176536-ac08-4607-b003-11caa3cc5e31"),
                Name = nameof(UserTypes.GetUsers),
                DisplayName = "Listar Usuarios",
                Order = 2
            },
            new()
            {
                Id = new Guid("cb5095c0-02cd-4b10-8666-09eaafeda595"),
                Name = nameof(UserTypes.GetUserById),
                DisplayName = "Detalle del Usuario",
                Order = 3
            },
            new()
            {
                Id = new Guid("73eadeb6-bc84-4d98-ab6e-04f85e057db7"),
                Name = nameof(UserTypes.AddUser),
                DisplayName = "Crear Usuario",
                Order = 4
            },
            new()
            {
                Id = new Guid("942d6f21-a7f7-43cd-9588-23657911fea2"),
                Name = nameof(UserTypes.EditUser),
                DisplayName = "Editar Usuario",
                Order = 5
            },
            new()
            {
                Id = new Guid("a984910b-6ecc-43e0-82d5-e9c9b0c78d03"),
                Name = nameof(UserTypes.RemoveUser),
                DisplayName = "Eliminar Usuario",
                Order = 6
            }
        };

        public Guid? this[UserTypes type] => List.SingleOrDefault(permission => permission.Name == Enum.GetName(type))?.Id;
    }
}
