namespace Mongo_Net7_Demo.Models;

public class SchoolDatabaseSettings : ISchoolDatabaseSettings
{
    public string StudentCollectionName { get; set; } 
    public string CoursesCollectionName { get; set; }
    public string ConnectingString { get; set; }
    public string DatabaseName { get; set; }
}