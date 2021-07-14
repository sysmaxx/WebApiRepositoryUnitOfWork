using DemoWebApp.Persistence.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoWebApp.Persistence
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        IAuthorRepository Authors { get; }
        IArticleRepository Articles { get; }
        ICommentRepository Comments { get; }

        int Complete();
        Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    }
}
