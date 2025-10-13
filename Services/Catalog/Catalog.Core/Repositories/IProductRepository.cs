using Catalog.Core.Entities;
using Catalog.Core.Specs;

namespace Catalog.Core.Repositories
{
    public interface IProductRepository
    {
        Task<Pagination<Product>> GetProductsAsync(CatalogSpecParams catalog);
        Task<Product> GetProductByIdAsync(string id);
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
        Task<IEnumerable<Product>> GetProductsByBrandAsync(string name);
        Task<IEnumerable<Product>> GetProductsByTypeAsync(string name);
        Task<Product> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(string id);
    }
}
