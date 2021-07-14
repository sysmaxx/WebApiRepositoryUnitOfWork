using DemoWebApp.Models;
using EntityRepositoryLibrary;

namespace DemoWebApp.Persistence.Repositories
{
    public interface ICommentRepository : IRepository<Comment>, IRepositoryAsync<Comment>
    {
    }
}
