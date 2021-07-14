using System;
using System.Collections.Generic;

namespace DemoWebApp.Models
{
    public partial class Article 
    {
        public Article()
        {
            Comments = new HashSet<Comment>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; }
        public DateTime Modified { get; }
        public long AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
