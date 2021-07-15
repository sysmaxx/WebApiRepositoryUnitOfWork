using DemoWebApp.Persistence.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoWebApp.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAuthorRepository Authors { get; private set; }
        public IArticleRepository Articles { get; private set; }
        public ICommentRepository Comments { get; private set; }


        private readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
            InstantiateRepositories(_context);
        }

        private void InstantiateRepositories(Context context)
        {
            Authors = new AuthorRepository(context);
            Articles = new ArticleRepository(context);
            Comments = new CommentRepository(context);
        }

        public int Complete() => _context.SaveChanges();
        public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        public void Dispose()
        {
            if (_context is not null)
                _context.Dispose();

            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            if (_context is not null)
                await _context.DisposeAsync().ConfigureAwait(false);
        }
    }
}
