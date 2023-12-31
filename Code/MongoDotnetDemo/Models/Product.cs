using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDotnetDemo.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? ProductName { get; set; }
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string? CategoryId { get; set; }

        [BsonIgnoreIfNull]
        public string? CategoryName { get; set; }
    }
}