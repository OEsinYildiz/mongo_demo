using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo_Net7_Demo.Entities;

public class Student
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [Required(ErrorMessage = "Firstname is required.")]
    public string FirstName { get; set; }

    public string LastName { get; set; }
    public string Major { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> Courses { get; set; }

    [BsonIgnore]
    public List<Course>? CoursesList { get; set; }
}