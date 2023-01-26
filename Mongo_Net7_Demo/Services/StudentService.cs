using Mongo_Net7_Demo.Entities;
using Mongo_Net7_Demo.Models;
using MongoDB.Driver;

namespace Mongo_Net7_Demo.Services;

public class StudentService
{
    private readonly IMongoCollection<Student> _collection;
    public StudentService(ISchoolDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectingString);
        var database = client.GetDatabase(settings.DatabaseName);
        _collection = database.GetCollection<Student>(settings.StudentCollectionName);
    }

    public async Task<List<Student>> GetAllStudentAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<Student> GetByIdAsync(string id) => 
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    

    public async Task<Student> CreateAsync(Student student)
    {
        await _collection.InsertOneAsync(student);
        return student;
    }

    public async Task UpdateAsync(string id, Student student) =>
        await _collection.ReplaceOneAsync(x => x.Id == id, student);
}