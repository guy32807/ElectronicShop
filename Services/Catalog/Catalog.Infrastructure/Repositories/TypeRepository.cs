using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class TypeRepository(ICatalogContext context) : ITypeRepository
    {
        public async Task<IEnumerable<ProductType>> GetTypesAsync()
        {
            return await context.Types.Find(p => true).ToListAsync();
        }
    }
}
