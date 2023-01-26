using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo_Net7_Demo.Entities;

public class Course
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }
    public string Code { get; set; }
}