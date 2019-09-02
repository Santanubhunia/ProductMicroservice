using Microsoft.AspNetCore.Mvc;
using ProductsMicroserviceMongoDB.Models;
using ProductsMicroserviceMongoDB.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ProductsMicroserviceMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository productRepo;
        public ProductsController(IProductRepository productRepo)
        {
            this.productRepo = productRepo;
        }
        // GET api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return productRepo.GetProducts().ToList();
        }

        // GET api/Products/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(string id)
        {
            return productRepo.GetProductById(id);
        }

        // POST api/Products
        [HttpPost]
        public Product InsertProduct([FromBody] Product product)
        {
            return productRepo.InsertProduct(product);
        }

        // PUT api/Products/5
        [HttpPut("{id}")]
        public Product UpdateProduct(string id, [FromBody] Product product)
        {
            return productRepo.UpdateProduct(id, product);
        }

        // DELETE api/Products/5
        [HttpDelete("{id}")]
        public void DeleteProduct(string id)
        {
            productRepo.DeleteProduct(id);
        }
        // DELETE api/Products/5
        [HttpDelete]
        public void DeleteProduct([FromBody] Product product)
        {
            productRepo.DeleteProduct(product);
        }
    }
}
