using System;
using System.Collections.Generic;

namespace DemoWebApp.Models
{
    public partial class Author 
    {
        public Author()
        {
            Articles = new HashSet<Article>();
            Comments = new HashSet<Comment>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; }
        public DateTime Modified { get; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
