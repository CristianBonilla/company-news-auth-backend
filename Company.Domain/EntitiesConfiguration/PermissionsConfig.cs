using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Domain
{
    class PermissionsConfig :
        IEntityTypeConfiguration<RolesPermission>,
        IEntityTypeConfiguration<UsersPermission>,
        IEntityTypeConfiguration<NewsPermission>
    {
        public void Configure(EntityTypeBuilder<RolesPermission> builder) => builder.HasData(SeedData.SeedPermissions.SeedRoles);

        public void Configure(EntityTypeBuilder<UsersPermission> builder) => builder.HasData(SeedData.SeedPermissions.SeedUsers);

        public void Configure(EntityTypeBuilder<NewsPermission> builder) => builder.HasData(SeedData.SeedPermissions.SeedNews);
    }
}
