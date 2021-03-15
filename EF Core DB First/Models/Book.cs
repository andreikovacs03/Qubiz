using System;
using System.Collections.Generic;

#nullable disable

namespace EF_Core_DB_First.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string AuthorName { get; set; }
        public string BookName { get; set; }
    }
}
