using MongoDB.Driver;
using ProductsMicroserviceMongoDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductsMicroserviceMongoDB.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> products;

        public ProductRepository(IProductDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            products = database.GetCollection<Product>(settings.ProductsCollectionName);
        }


        public Product GetProductById(string id)
        {
            return products.Find<Product>(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetProducts()
        {
            return products.Find(product => true).ToList();
        }

        public Product InsertProduct(Product product)
        {
            products.InsertOne(product);
            return product;
        }

        public Product UpdateProduct(string id, Product product)
        {
            products.ReplaceOne(p => p.Id == id, product);
            return product;
        }

        public void DeleteProduct(Product product)
        {
            products.DeleteOne(p => p.Id == product.Id);
        }

        public void DeleteProduct(string id)
        {
            products.DeleteOne(book => book.Id == id);
        }

    }
}
