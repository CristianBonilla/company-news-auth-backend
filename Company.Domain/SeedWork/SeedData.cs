using System.Linq;
using System.Collections.Generic;

namespace Company.Domain
{
    class SeedData
    {
        public static NewsEntity[] SeedNews { get; } = new NewsEntity[]
        {
            new()
            {
                Title = "Solo hay 4 mujeres en los CEO de las 100 empresas más grandes",
                Description = "Figuran ejecutivas de D1, Cencosud, Cerrejón y Comparta. Tres de ellas asumieron en los últimos dos años"
            },
            new()
            {
                Title = "Crédito de Scotiabank Colpatria por US$100 millones a AES Colombia",
                Description = "El préstamo, incluye recursos para la construcción del Parque Solar San Fernando (Meta) por cerca de US$35 millones"
            },
            new()
            {
                Title = "Google y Facebook firman asociación con empresa de pago en línea",
                Description = "Se trata de Shopify, que brindará soporte y apoyo a comerciantes que no usan directamente su plataforma"
            },
            new()
            {
                Title = "Bitcóin: hackers tienen nuevo método para robar criptomonedas",
                Description = "Los delincuentes envían cartas a las viviendas de sus víctimas haciéndose pasar por la compañía Ledger. En el documento piden a las personas compartir su información en un nuevo dispositivo para supuestamente mantener los datos seguros"
            },
            new()
            {
                Title = "'Startup' Habi recauda 100 millones de dólares en ronda de inversión",
                Description = "Habi, la startup con sede en Colombia, anunció este miércoles que recaudó 100 millones de dólares en la ronda de financiación de serie B por parte de SoftBank Latin American Fund, junto con inversores de Inspired Capital, Tiger Global, Homebrew y 8VC"
            },
            new()
            {
                Title = "E3: los mejores anuncios que dejó el evento en su edición virtual",
                Description = "Después de un año de ausencia por la pandemia, finalmente el Electronic Entertainment Expo (E3) volvió con varias novedades para los amantes de los videojuegos, aunque no cumplió todas las expectativas en materia de los anuncios que se tenían presupuestados"
            }
        };

        public static RoleEntity[] SeedRoles { get; } = new[]
        {
            DefaultUserRoles.AdminUser.Role,
            DefaultUserRoles.VisitorUser.Role,
            DefaultUserRoles.AssistantUser.Role,
            DefaultUserRoles.EditorUser.Role
        };

        public static PermissionEntity[] SeedPermissions { get; } = new PermissionEntity[]
        {
            Roles.ALL,
            Roles.GetRoles,
            Roles.GetRoleById,
            Roles.GetPermissions,
            Roles.GetPermissionsByRole,
            Users.ALL,
            Users.GetUsers,
            Users.GetUserById,
            Users.AddUser,
            Users.EditUser,
            Users.RemoveUser,
            News.ALL,
            News.GetNews,
            News.GetNewsById
        };

        public static RolePermissionEntity[] SeedRolePermissionList()
        {
            var allRolePermissionList = RolePermissionList(DefaultUserRoles.AdminUser)
                .Concat(RolePermissionList(DefaultUserRoles.VisitorUser))
                .Concat(RolePermissionList(DefaultUserRoles.AssistantUser))
                .Concat(RolePermissionList(DefaultUserRoles.EditorUser));

            return allRolePermissionList.ToArray();
        }

        private static IEnumerable<RolePermissionEntity> RolePermissionList((RoleEntity Role, PermissionEntity[] Permissions) defaultUserRole)
        {
            var (Role, Permissions) = defaultUserRole;

            foreach (PermissionEntity permission in Permissions)
                yield return new() { Role = Role, Permission = permission };
        }
    }
}
