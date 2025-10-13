using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public static class CatalogContextSeed
    {
        public static void SeedData<T>(IMongoCollection<T> collection, string fileName)
        {
            bool existData = collection.Find(p => true).Any();
            string path = Path.Combine("Data", "SeedData", fileName);
            if (!existData)
            {
                var data = File.ReadAllText(path);
                var items = JsonSerializer.Deserialize<List<T>>(data);
                if (items != null && items.Count > 0)
                {
                    collection.InsertManyAsync(items);
                }
            }
        }
    }
}
