namespace ProductsMicroserviceMongoDB.Models
{
    public interface IProductDatabaseSettings
    {
         string ProductsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
