using DemoWebApp.Models;
using DemoWebApp.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApp.Persistence
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
        }

        //public override int SaveChanges()
        //{
        //    UpdateChangedModifiedFields();
        //    return base.SaveChanges();
        //}

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    UpdateChangedModifiedFields();
        //    return base.SaveChangesAsync(cancellationToken);
        //}

        //private void UpdateChangedModifiedFields()
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
        //    {
        //        if (entry.Entity is IHasModifiedField lastModified)
        //            lastModified.Modified = DateTime.Now;
        //    }
        //}
    }
}
