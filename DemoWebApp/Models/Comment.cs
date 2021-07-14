using System;

namespace DemoWebApp.Models
{
    public partial class Comment 
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public long AuthorId { get; set; }
        public long ArticleId { get; set; }
        public DateTime Created { get; }
        public DateTime Modified { get; }

        public virtual Article Article { get; set; }
        public virtual Author Author { get; set; }
    }
}
