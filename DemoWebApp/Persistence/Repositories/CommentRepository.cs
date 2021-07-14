using DemoWebApp.Models;
using EntityRepositoryLibrary;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApp.Persistence.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context) { }
    }
}
