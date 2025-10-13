﻿using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public static class ProductContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            string path = Path.Combine("Data", "SeedData", "products.json");
            if (!existProduct)
            {
                var productsData = File.ReadAllText(path);
                //var productsData = File.ReadAllText("../Catalog.Infrastructure/Data/DataSeeds/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products != null && products.Count > 0)
                {
                    productCollection.InsertManyAsync(products);
                }
            }
        }
    }
}
