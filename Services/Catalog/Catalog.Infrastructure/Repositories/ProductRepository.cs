using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Core.Specs;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository(ICatalogContext context) : IProductRepository
    {
        public async Task<Pagination<Product>> GetProductsAsync(CatalogSpecParams catalog)
        {
            var builder = Builders<Product>.Filter;
            var filter = builder.Empty;
            if (!string.IsNullOrEmpty(catalog.Search))
            {
                filter &= builder.Eq(p => p.Name, catalog.Search);
            }

            if (!string.IsNullOrEmpty(catalog.BrandId))
            {
                var brandFilter = builder.Eq(p => p.Brands.Id, catalog.BrandId);
                filter &= brandFilter;
            }
            if (!string.IsNullOrEmpty(catalog.TypeId))
            {
                var typeFilter = builder.Eq(p => p.Types.Id, catalog.TypeId);
                filter &= typeFilter;
            }
            var totalItems = await context.Products.CountDocumentsAsync(filter);
            return new Pagination<Product>(catalog.PageIndex, catalog.PageSize, totalItems, await DataFilter(catalog, filter));
        }

        private async Task<IReadOnlyList<Product>> DataFilter(CatalogSpecParams catalog, FilterDefinition<Product> filter)
        {
            var sortDefinition = new SortDefinitionBuilder<Product>();
            return catalog.Sort switch
            {
                "priceAsc" => await context
                .Products
                .Find(filter)
                .Sort(sortDefinition
                .Ascending(p => p.Price))
                .Skip((catalog.PageIndex - 1) * catalog.PageSize)
                .Limit(catalog.PageSize)
                .ToListAsync(),
                "priceDesc" => await context
                .Products
                .Find(filter)
                .Sort(sortDefinition
                .Descending(p => p.Price))
                .Skip((catalog.PageIndex - 1) * catalog.PageSize)
                .Limit(catalog.PageSize)
                .ToListAsync(),
                _ => await context
                .Products
                .Find(filter)
                .Sort(sortDefinition
                .Ascending(p => p.Name))
                .Skip((catalog.PageIndex - 1) * catalog.PageSize)
                .Limit(catalog.PageSize)
                .ToListAsync(),
            };
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            await context.Products.InsertOneAsync(product);
            return product;
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            return await context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByBrandAsync(string brandName)
        {
            return await context.Products.Find(p => p.Brands.Name.ToLower() == brandName.ToLower()).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            return await context.Products.Find(p => p.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByTypeAsync(string type)
        {
            return await context.Products.Find(p => p.Types.Name.ToLower() == type.ToLower()).ToListAsync();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var updatedProduct = await context.Products.ReplaceOneAsync(p => p.Id == product.Id, product);
            return updatedProduct.IsAcknowledged && updatedProduct.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            var deletedProduct = await context.Products.DeleteOneAsync(p => p.Id == id);
            return deletedProduct.IsAcknowledged && deletedProduct.DeletedCount > 0;
        }
    }
}
