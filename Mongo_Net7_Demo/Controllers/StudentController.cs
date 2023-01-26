using Microsoft.AspNetCore.Mvc;
using Mongo_Net7_Demo.Entities;
using Mongo_Net7_Demo.Services;

namespace Mongo_Net7_Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly StudentService _studentService;
    private readonly CourseService _courseService;

    public StudentController(StudentService studentService, CourseService courseService)
    {
        _studentService = studentService;
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var students = await _studentService.GetAllStudentAsync();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudentById(string id)
    {
        var student = await _studentService.GetByIdAsync(id);

        if (student.Courses.Count > 0)
        {
            List<Course> tempList = new();
            foreach (var itemId in student.Courses)
            {
                var course = await _courseService.GetCourseById(itemId);
                tempList.Add(course);
                //student.CoursesList.Add(course);
            }

            student.CoursesList = tempList;
        }

        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(Student student)
    {
        var result = await _studentService.CreateAsync(student);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(string id, Student student)
    {
        var studentCheck = await _studentService.GetByIdAsync(id);

        if (studentCheck is null)
            return NotFound();

        await _studentService.UpdateAsync(id, student);
        return NoContent();
    }
}