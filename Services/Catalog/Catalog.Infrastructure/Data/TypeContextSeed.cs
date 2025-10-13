using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public static class TypeContextSeed
    {
        public static void SeedData(IMongoCollection<ProductType> typeCollection)
        {
            var checkType = typeCollection.Find(p => true).Any();
            string path = Path.Combine("Data", "SeedData", "types.json");
            if (!checkType)
            {
                var typesData = File.ReadAllText(path);
                //var typesData = File.ReadAllText("../Catalog.Infrastructure/Data/DataSeeds/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                if (types != null && types.Count > 0)
                {
                    typeCollection.InsertManyAsync(types);
                }
            }
        }
    }
}
