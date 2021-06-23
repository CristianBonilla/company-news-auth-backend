using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Domain
{
    class NewsConfig : IEntityTypeConfiguration<NewsEntity>
    {
        public void Configure(EntityTypeBuilder<NewsEntity> builder)
        {
            builder.ToTable("News", "dbo")
                .HasKey(key => key.Id);
            builder.Property(property => property.Id)
                .HasDefaultValueSql("NEWID()");
            builder.Property(property => property.Title)
                .HasMaxLength(150)
                .IsUnicode()
                .IsRequired();
            builder.Property(property => property.Description)
                .HasColumnType("nvarchar(max)")
                .IsRequired();
            builder.Property(property => property.Creation)
                .HasDefaultValueSql("GETDATE()");
            builder.Property(property => property.Updated)
                .IsRequired();
            builder.HasData(SeedData.SeedNews);
        }
    }
}
