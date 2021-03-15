using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_101.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-SA5JHSJ;Database=ASP-Core-101-DB;Integrated Security=True");
        }
    }
}
