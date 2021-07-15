using DemoWebApp.Models;
using EntityRepositoryLibrary;

namespace DemoWebApp.Persistence.Repositories
{
    public interface IAuthorRepository : IRepositorySync<Author>, IRepositoryAsync<Author>
    {
    }
}
