using System;
using System.Collections.Generic;
using System.Linq;
using ASP.NET_Core_101.Models;
using Microsoft.AspNetCore.Hosting;

namespace ASP.NET_Core_101.Services
{
    public class DbProductService
    {
        public DbProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public IEnumerable<Product> GetProducts() => new AppDBContext().Products;
        public IEnumerable<Rating> GetRatings() => new AppDBContext().Ratings;

        public void AddRating(int stars, string productId)
        {
            using var db = new AppDBContext();
            
            db.Ratings.Add(new Rating { Stars = stars, ProductId = productId });
            db.SaveChanges();

            db.Dispose();
        }
    }
}
