using DemoWebApp.Models;
using EntityRepositoryLibrary;

namespace DemoWebApp.Persistence.Repositories
{
    public interface IArticleRepository : IRepositorySync<Article>, IRepositoryAsync<Article>
    {
        Article GetArticleWithAuthorAndCommentsById(int id);
    }
}
