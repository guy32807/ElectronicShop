using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public static class BrandContextSeed
    {
        public static void SeedData(IMongoCollection<ProductBrand> brandCollection)
        {
            bool existBrand = brandCollection.Find(p => true).Any();
            string path = Path.Combine("Data", "SeedData", "brands.json");
            if (!existBrand)
            {
                var brandsData = File.ReadAllText(path);
                //var brandsData = File.ReadAllText("../Catalog.Infrastructure/Data/DataSeeds/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if (brands != null && brands.Count > 0)
                {
                    brandCollection.InsertManyAsync(brands);
                }
            }
        }
    }
}
