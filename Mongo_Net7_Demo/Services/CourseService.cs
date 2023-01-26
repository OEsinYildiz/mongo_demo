using Mongo_Net7_Demo.Entities;
using Mongo_Net7_Demo.Models;
using MongoDB.Driver;

namespace Mongo_Net7_Demo.Services;

public class CourseService
{
    private readonly IMongoCollection<Course> _collection;
    
    public CourseService(ISchoolDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectingString);
        var database = client.GetDatabase(settings.DatabaseName);
        _collection = database.GetCollection<Course>(settings.CoursesCollectionName);
    }

    public async Task<Course> GetCourseById(string id)
    {
        return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
}