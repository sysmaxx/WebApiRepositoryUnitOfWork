using DemoWebApp.Models;
using EntityRepositoryLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApp.Persistence.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(DbContext context) : base(context) { }

        public Article GetArticleWithAuthorAndCommentsById(int id) 
            => Context<Context>().Articles
                .Include(a => a.Author)
                .Include(a => a.Comments)
                .SingleOrDefault(x => x.Id == id);
    }
}
