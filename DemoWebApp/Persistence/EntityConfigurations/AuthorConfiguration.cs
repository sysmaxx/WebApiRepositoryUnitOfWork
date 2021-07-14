using DemoWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoWebApp.Persistence.EntityConfigurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(sysdatetime())")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(sysdatetime())")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.ToTable(nameof(Author));
        }
    }
}
