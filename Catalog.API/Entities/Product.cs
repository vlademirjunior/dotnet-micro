using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("n")]
        public string Name { get; set; }

        [BsonElement("c")]
        public string Category { get; set; }

        [BsonElement("d")]
        public string Description { get; set; }

        [BsonElement("i")]
        public string Image { get; set; }

        [BsonElement("p")]
        public decimal Price { get; set; }
    }
}