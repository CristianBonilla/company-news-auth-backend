using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Domain
{
    class RolePermissionConfig :
        IEntityTypeConfiguration<RoleEntity>,
        IEntityTypeConfiguration<PermissionEntity>,
        IEntityTypeConfiguration<RolePermissionEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable("Role", "dbo")
                .HasKey(key => key.Id);
            builder.Property(property => property.Id)
                .HasDefaultValueSql("NEWID()");
            builder.Property(property => property.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsRequired();
            builder.Property(property => property.DisplayName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();
            builder.HasIndex(index => new { index.Name })
                .IsUnique();
            builder.HasData(SeedData.SeedRoles);
        }

        public void Configure(EntityTypeBuilder<PermissionEntity> builder)
        {
            builder.ToTable("Permission", "dbo")
                .HasKey(key => key.Id);
            builder.Property(property => property.Id)
                .HasDefaultValueSql("NEWID()");
            builder.Property(property => property.Type)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();
            builder.Property(property => property.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsRequired();
            builder.Property(property => property.DisplayName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();
            builder.Property(property => property.Order)
                .IsRequired();
            builder.HasIndex(index => new { index.Type, index.Name })
                .IsUnique();
            builder.HasDiscriminator(discriminator => discriminator.Type)
                .HasValue<RolesPermission>(PermissionTypes.CanRoles)
                .HasValue<UsersPermission>(PermissionTypes.CanUsers)
                .HasValue<NewsPermission>(PermissionTypes.CanNews)
                .IsComplete();
        }

        public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
        {
            builder.ToTable("RolePermission", "dbo")
                .HasKey(key => new { key.RoleId, key.PermissionId });
            builder.HasOne(one => one.Role)
                .WithMany()
                .HasForeignKey(key => key.RoleId);
            builder.HasOne(one => one.Permission)
                .WithMany()
                .HasForeignKey(key => key.PermissionId);
            builder.HasData(SeedData.SeedRolePermissionList);
        }
    }
}
