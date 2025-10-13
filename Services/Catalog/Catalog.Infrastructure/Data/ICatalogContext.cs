using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public interface ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }
        public IMongoCollection<ProductBrand> Brands { get; }
        public IMongoCollection<ProductType> Types { get; }
    }
}
