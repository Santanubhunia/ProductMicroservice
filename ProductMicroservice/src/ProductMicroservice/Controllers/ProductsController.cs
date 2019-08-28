using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Models;
using ProductMicroservice.Repository;

namespace ProductMicroservice.Controllers
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
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return productRepo.GetProducts().ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            return productRepo.GetProductById(id);
        }

        // POST api/values
        [HttpPost]
        public Product InsertProduct([FromBody] Product product)
        {
            return productRepo.InsertProduct(product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Product Put(int id, [FromBody] Product product)
        {
            return productRepo.UpdateProduct(product);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Product Delete(int id)
        {
            return productRepo.DeleteProduct(id);
        }
    }
}
