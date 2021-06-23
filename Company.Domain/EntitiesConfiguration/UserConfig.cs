using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Domain
{
    class UserConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User", "dbo")
                .HasKey(key => key.Id);
            builder.Property(property => property.Id)
                .HasDefaultValueSql("NEWID()");
            builder.Property(property => property.IdentificationNumber)
                .IsRequired();
            builder.Property(property => property.Username)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(property => property.Password)
                .HasColumnType("nvarchar(max)")
                .IsRequired();
            builder.Property(property => property.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .IsRequired();
            builder.Property(property => property.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
            builder.Property(property => property.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
            builder.HasOne(one => one.Role)
                .WithMany()
                .HasForeignKey(key => key.RoleId);
            builder.HasIndex(index => new { index.IdentificationNumber, index.Username, index.Email })
                .IsUnique();
        }
    }
}
