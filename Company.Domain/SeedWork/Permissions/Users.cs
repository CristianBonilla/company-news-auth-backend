using System;

namespace Company.Domain
{
    public class UsersPermission : PermissionEntity
    {
        const string CanUsers = nameof(CanUsers);
        public new string Type { get; } = CanUsers;
    }

    public class Users
    {
        public static UsersPermission ALL { get; } = new()
        {
            Id = new Guid("d3683aa7-defb-48ea-8459-b17a34a0c363"),
            Name = nameof(ALL),
            DisplayName = "Todos",
            Order = 1
        };
        public static UsersPermission GetUsers { get; } = new()
        {
            Id = new Guid("f6176536-ac08-4607-b003-11caa3cc5e31"),
            Name = nameof(GetUsers),
            DisplayName = "Listar Usuarios",
            Order = 2
        };
        public static UsersPermission GetUserById { get; } = new()
        {
            Id = new Guid("cb5095c0-02cd-4b10-8666-09eaafeda595"),
            Name = nameof(GetUserById),
            DisplayName = "Detalle del Usuario",
            Order = 3
        };
        public static UsersPermission AddUser { get; } = new()
        {
            Id = new Guid("73eadeb6-bc84-4d98-ab6e-04f85e057db7"),
            Name = nameof(AddUser),
            DisplayName = "Crear Usuario",
            Order = 4
        };
        public static UsersPermission EditUser { get; } = new()
        {
            Id = new Guid("942d6f21-a7f7-43cd-9588-23657911fea2"),
            Name = nameof(EditUser),
            DisplayName = "Editar Usuario",
            Order = 5
        };
        public static UsersPermission RemoveUser { get; } = new()
        {
            Id = new Guid("a984910b-6ecc-43e0-82d5-e9c9b0c78d03"),
            Name = nameof(RemoveUser),
            DisplayName = "Eliminar Usuario",
            Order = 6
        };
    }
}
