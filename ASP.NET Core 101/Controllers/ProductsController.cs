using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_101.Models;
using ASP.NET_Core_101.Services;

namespace ASP.NET_Core_101.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(DbProductService productService)
        {
            ProductService = productService;
        }

        public DbProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get() => ProductService.GetProducts();

        [Route("Rate")]
        [HttpGet]
        public ActionResult Get(
            [FromQuery] string ProductId,
            [FromQuery] int Star)
        {
            ProductService.AddRating(Star, ProductId);
            return Ok();
        }
    }
}
