using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using SchoolGradesWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;



public class StudentsController : Controller
{
    private readonly ApplicationDbContext _context; // Assuming you have a DbContext for your application
    private readonly string _connectionString = "Server=localhost; Database=SchoolGrades; Uid=kaizen; Pwd=Admin@231527; Port=3307;";

    public StudentsController(ApplicationDbContext context) // Dependency injection of the DbContext
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Add([FromBody] Student student)
    {
        if (ModelState.IsValid)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO students (student_name, subject_name, grade) VALUES (@StudentName, @SubjectName, @Grade)";
                command.Parameters.AddWithValue("@StudentName", student.Name);
                command.Parameters.AddWithValue("@SubjectName", student.Subject);
                command.Parameters.AddWithValue("@Grade", student.Grade);

                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    var students = GetStudents();
                    return Json(new { success = true, students });
                }
            }
        }
        return Json(new { success = false });
    }
    public IActionResult Index()
    {
        var students = GetStudents();
        return View(students);
    }

    [HttpDelete("Delete/{studentId}")]
    public IActionResult Delete(int studentId)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM students WHERE student_id = @StudentId";
            command.Parameters.AddWithValue("@StudentId", studentId);

            var result = command.ExecuteNonQuery();
            if (result > 0)
            {
                // Student deleted successfully
                return Json(new { success = true });
            }
        }
        // If no rows affected, return success as false
        return Json(new { success = false });
    }

    private List<Student> GetStudents()
    {
        List<Student> students = new List<Student>();

        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            var command = new MySqlCommand("SELECT student_id, student_name, subject_name, grade FROM students", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = reader.GetInt32("student_id"),
                        Name = reader.GetString("student_name"),
                        Subject = reader.GetString("subject_name"),
                        Grade = reader.GetDecimal("grade").ToString()
                    });
                }
            }
        }

        return students;
    }

 

    public IActionResult GetAllStudents()
    {
        var students = GetStudents();
        return Json(new { students });
    }

    [HttpPut("Update/{studentId}/{name}/{subject}/{grade}")]
    public async Task<IActionResult> Update(int studentId, string name, string subject, int grade)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE students SET student_name = @StudentName, subject_name = @SubjectName, grade = @Grade WHERE student_id = @StudentId";
            command.Parameters.AddWithValue("@StudentId", studentId);
            command.Parameters.AddWithValue("@StudentName", name);
            command.Parameters.AddWithValue("@SubjectName", subject);
            command.Parameters.AddWithValue("@Grade", grade);

            var result = await command.ExecuteNonQueryAsync();
            if (result > 0)
            {
                return Json(new { success = true });
            }
        }

        return Json(new { success = false });
    }



}

