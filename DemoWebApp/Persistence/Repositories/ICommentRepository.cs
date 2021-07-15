using DemoWebApp.Models;
using EntityRepositoryLibrary;

namespace DemoWebApp.Persistence.Repositories
{
    public interface ICommentRepository : IRepositorySync<Comment>, IRepositoryAsync<Comment>
    {
    }
}
