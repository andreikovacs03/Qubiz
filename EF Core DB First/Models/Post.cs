using System;
using System.Collections.Generic;

#nullable disable

namespace EF_Core_DB_First.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
