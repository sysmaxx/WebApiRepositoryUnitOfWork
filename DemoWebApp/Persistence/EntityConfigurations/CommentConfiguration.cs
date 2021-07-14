using DemoWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoWebApp.Persistence.EntityConfigurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
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
                .ValueGeneratedOnAdd();

            builder.HasOne(d => d.Article)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.ArticleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Article_Comment");

            builder.HasOne(d => d.Author)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Author_Comment");

            builder.ToTable(nameof(Comment));
        }
    }
}
