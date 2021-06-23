using System;

namespace Company.Domain
{
    public class Users
    {
        public static PermissionEntity ALL { get; } = new()
        {
            Id = new Guid("d3683aa7-defb-48ea-8459-b17a34a0c363"),
            Order = 1,
            Name = nameof(ALL),
            DisplayName = "Todos"
        };
        public static PermissionEntity GetUsers { get; } = new()
        {
            Id = new Guid("f6176536-ac08-4607-b003-11caa3cc5e31"),
            Order = 2,
            Name = nameof(GetUsers),
            DisplayName = "Listar Usuarios"
        };
        public static PermissionEntity GetUserById { get; } = new()
        {
            Id = new Guid("cb5095c0-02cd-4b10-8666-09eaafeda595"),
            Order = 3,
            Name = nameof(GetUserById),
            DisplayName = "Detalle del Usuario"
        };
        public static PermissionEntity AddUser { get; } = new()
        {
            Id = new Guid("73eadeb6-bc84-4d98-ab6e-04f85e057db7"),
            Order = 4,
            Name = nameof(AddUser),
            DisplayName = "Crear Usuario"
        };
        public static PermissionEntity EditUser { get; } = new()
        {
            Id = new Guid("942d6f21-a7f7-43cd-9588-23657911fea2"),
            Order = 5,
            Name = nameof(EditUser),
            DisplayName = "Editar Usuario"
        };
        public static PermissionEntity RemoveUser { get; } = new()
        {
            Id = new Guid("a984910b-6ecc-43e0-82d5-e9c9b0c78d03"),
            Order = 6,
            Name = nameof(RemoveUser),
            DisplayName = "Eliminar Usuario"
        };
    }
}
