using Microsoft.AspNetCore.Mvc;
using Prueba_tecnica_P1.Models;
using Prueba_tecnica_P1.Repository;
using System.Data;

namespace Prueba_tecnica_P1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController:ControllerBase
    {
  
        private readonly Productos_Repository products_repository;
        private readonly IConfiguration _configuration;
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
            products_repository = new Productos_Repository(_configuration.GetConnectionString("DefaultConnection"));
        }

        [HttpGet(Name = "GetProducts")]
        public IList<Product> product(){

            var products = products_repository.GetProductos();
            var productList = new List<Product>();

            foreach (DataRow product in products.Rows) { 
                string name = product["Name"].ToString();
                string description = product["Description"].ToString();
                double price = Double.Parse(product["Price"].ToString());
                productList.Add(new Product { Name =  name,Description = description, Price = price });

            }
            return productList;
        }
    }
}
