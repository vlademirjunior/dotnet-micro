using System.Collections.Generic;
using Bogus;
using Catalog.API.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public static class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(_ => true).Any();

            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetMyProducts());
            }
        }

        public static IEnumerable<Product> GetMyProducts()
        {
            return new Faker<Product>("pt_BR")
                .RuleFor(p => p.Id, _ => ObjectId.GenerateNewId().ToString())
                .RuleFor(p => p.Category, f => f.Commerce.Categories(1)[0])
                .RuleFor(p => p.Name, f => f.Commerce.Product())
                .RuleFor(p => p.Price, f => f.Commerce.Price()[0])
                .RuleFor(p => p.Image, f => f.Internet.Avatar())
                .RuleFor(p => p.Description, f => f.Commerce.ProductAdjective())
                .Generate(20);
        }
    }
}