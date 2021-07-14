using DemoWebApp.Models;
using EntityRepositoryLibrary;

namespace DemoWebApp.Persistence.Repositories
{
    public interface IArticleRepository : IRepository<Article>, IRepositoryAsync<Article>
    {
    }
}
