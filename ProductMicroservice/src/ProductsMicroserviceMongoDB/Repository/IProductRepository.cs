using ProductsMicroserviceMongoDB.Models;
using System.Collections.Generic;

namespace ProductsMicroserviceMongoDB.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(string id);
        Product InsertProduct(Product product);
        Product UpdateProduct(string id, Product product);
        void DeleteProduct(string id);
        void DeleteProduct(Product product);
    }
}
