using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EF_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://docs.microsoft.com/en-us/ef/core/
            // Dependencies
            // Entity Framework
            // EF Tools
            // MSQL Core entityframework
            
            // Package Manager Console
            // add-migration <string>
            // update-database
            // roll-back : update-database -migration "<full-migration-filename>"  

            using (var context = new AppDBContext())
            {
                var blog = new Blog { Url = "http://example.com", Rating = 5 };
                context.Blogs.Add(blog);
                context.SaveChanges();

                var blog2 = new Blog { Url = "http://example2.com", Rating = 5 };
                context.Blogs.Add(blog2);
                context.SaveChanges();

                var blogFromDB = context.Blogs.Where(x => x.BlogId == 1);

                Console.WriteLine(blogFromDB.ToQueryString());
            }
        }
    }
}
