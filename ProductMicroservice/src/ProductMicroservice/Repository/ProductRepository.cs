using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMicroservice.Models;
using ProductMicroservice.ProductDBContexts;

namespace ProductMicroservice.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDBContext dbcontext;
        public ProductRepository(ProductDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public Product DeleteProduct(int id)
        {
            var product = dbcontext.Products.Find(id);
            if (product != null)
            {
                dbcontext.Remove(product);
                dbcontext.SaveChanges();
            }
            return product;
        }

        public Product GetProductById(int id)
        {
            return dbcontext.Products.Find(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return dbcontext.Products;
        }

        public Product InsertProduct(Product product)
        {
            dbcontext.Products.Add(product);
            dbcontext.SaveChanges();
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            dbcontext.Products.Update(product);
            dbcontext.SaveChanges();
            return product;
        }
    }
}
