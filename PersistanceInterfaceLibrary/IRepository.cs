using Microsoft.EntityFrameworkCore;

namespace EntityRepositoryLibrary
{
    public interface IRepository<TEntity> : IRepositorySync<TEntity>, IRepositoryAsync<TEntity> where TEntity : class
    {
        TContext Context<TContext>() where TContext : DbContext;
    }
}
