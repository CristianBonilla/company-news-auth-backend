using System.Collections.Generic;

namespace Company.Domain
{
    class SeedData : DefaultUserRoles
    {
        public static IEnumerable<NewsEntity> SeedNews { get; } = new NewsEntity[]
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

        public static IEnumerable<RoleEntity> SeedRoles { get; } = new[]
        {
            AdminUser.Role,
            VisitorUser.Role,
            AssistantUser.Role,
            EditorUser.Role
        };

        public static IEnumerable<PermissionEntity> SeedPermissions
        {
            get
            {
                return GetPermissions();

                static IEnumerable<PermissionEntity> GetPermissions()
                {
                    foreach (RolesPermission permission in Roles.List)
                        yield return permission;
                    foreach (UsersPermission permission in Users.List)
                        yield return permission;
                    foreach (NewsPermission permission in News.List)
                        yield return permission;
                }
            }
        }

        public static IEnumerable<RolePermissionEntity> SeedRolePermissionList
        {
            get
            {
                return GetRolePermissionList();

                static IEnumerable<RolePermissionEntity> GetRolePermissionList()
                {
                    foreach (RolePermissionEntity rolePermission in Get(AdminUser))
                        yield return rolePermission;
                    foreach (RolePermissionEntity rolePermission in Get(EditorUser))
                        yield return rolePermission;
                    foreach (RolePermissionEntity rolePermission in Get(AssistantUser))
                        yield return rolePermission;
                    foreach (RolePermissionEntity rolePermission in Get(VisitorUser))
                        yield return rolePermission;

                    static IEnumerable<RolePermissionEntity> Get((RoleEntity Role, PermissionEntity[] Permissions) defaultUserRole)
                    {
                        var (Role, Permissions) = defaultUserRole;

                        foreach (PermissionEntity permission in Permissions)
                            yield return new() { Role = Role, Permission = permission };
                    }
                }
            }
        }
    }
}
