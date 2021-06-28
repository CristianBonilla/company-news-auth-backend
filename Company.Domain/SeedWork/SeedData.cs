using System;
using System.Linq;
using System.Collections.Generic;

namespace Company.Domain
{
    class SeedData : DefaultUserRoles
    {
        public static IEnumerable<NewsEntity> SeedNews { get; } = new NewsEntity[]
        {
            new()
            {
                Id = new Guid("47d0fc63-ccd3-48c6-825c-496a56db4adb"),
                Title = "Solo hay 4 mujeres en los CEO de las 100 empresas más grandes",
                Description = "Figuran ejecutivas de D1, Cencosud, Cerrejón y Comparta. Tres de ellas asumieron en los últimos dos años"
            },
            new()
            {
                Id = new Guid("056cff93-297c-4145-8035-ded5cbc32c61"),
                Title = "Crédito de Scotiabank Colpatria por US$100 millones a AES Colombia",
                Description = "El préstamo, incluye recursos para la construcción del Parque Solar San Fernando (Meta) por cerca de US$35 millones"
            },
            new()
            {
                Id = new Guid("9e77ccaf-98f6-426f-9f95-df113d985235"),
                Title = "Google y Facebook firman asociación con empresa de pago en línea",
                Description = "Se trata de Shopify, que brindará soporte y apoyo a comerciantes que no usan directamente su plataforma"
            },
            new()
            {
                Id = new Guid("b0ec35d4-9a19-4e6d-8cd2-817b968c2bb8"),
                Title = "Bitcóin: hackers tienen nuevo método para robar criptomonedas",
                Description = "Los delincuentes envían cartas a las viviendas de sus víctimas haciéndose pasar por la compañía Ledger. En el documento piden a las personas compartir su información en un nuevo dispositivo para supuestamente mantener los datos seguros"
            },
            new()
            {
                Id = new Guid("a6e7bad2-ac9c-407a-a0bb-2d32b51e794a"),
                Title = "'Startup' Habi recauda 100 millones de dólares en ronda de inversión",
                Description = "Habi, la startup con sede en Colombia, anunció este miércoles que recaudó 100 millones de dólares en la ronda de financiación de serie B por parte de SoftBank Latin American Fund, junto con inversores de Inspired Capital, Tiger Global, Homebrew y 8VC"
            },
            new()
            {
                Id = new Guid("c2cca9ea-b8c1-4abf-b70c-e47be5f06f92"),
                Title = "E3: los mejores anuncios que dejó el evento en su edición virtual",
                Description = "Después de un año de ausencia por la pandemia, finalmente el Electronic Entertainment Expo (E3) volvió con varias novedades para los amantes de los videojuegos, aunque no cumplió todas las expectativas en materia de los anuncios que se tenían presupuestados"
            }
        };

        public static IEnumerable<RoleEntity> SeedRoles { get; } = new[]
        {
            VisitorUser.Role,
            AssistantUser.Role,
            EditorUser.Role,
            AdminUser.Role
        };

        public class SeedPermissions
        {
            public static IEnumerable<RolesPermission> SeedRoles => Roles.List;
            public static IEnumerable<UsersPermission> SeedUsers => Users.List;
            public static IEnumerable<NewsPermission> SeedNews => News.List;
        }

        public static IEnumerable<RolePermissionEntity> SeedRolePermissionList
        {
            get
            {
                return GetRolePermissionList().ToArray();

                static IEnumerable<RolePermissionEntity> GetRolePermissionList()
                {
                    foreach (RolePermissionEntity rolePermission in Get(VisitorUser))
                        yield return rolePermission;
                    foreach (RolePermissionEntity rolePermission in Get(AssistantUser))
                        yield return rolePermission;
                    foreach (RolePermissionEntity rolePermission in Get(EditorUser))
                        yield return rolePermission;
                    foreach (RolePermissionEntity rolePermission in Get(AdminUser))
                        yield return rolePermission;

                    static IEnumerable<RolePermissionEntity> Get((RoleEntity Role, Guid[] PermissionIDs) defaultUserRole)
                    {
                        var (Role, PermissionIDs) = defaultUserRole;

                        foreach (Guid permissionId in PermissionIDs)
                            yield return new() { RoleId = Role.Id, PermissionId = permissionId };
                    }
                }
            }
        }
    }
}
