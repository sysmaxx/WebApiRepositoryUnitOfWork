using DemoWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoWebApp.Persistence.EntityConfigurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(e => e.Content)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(sysdatetime())")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(sysdatetime())")
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(d => d.Author)
                .WithMany(p => p.Articles)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Article_Author");

            builder.ToTable(nameof(Article));
        }
    }
}
