using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=.;Database=EnrollmentDB;Trusted_Connection=True;TrustServerCertificate=True"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();


// ================= MODELS =================

public class Course
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    public string Description { get; set; }

    public int Duration { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }
}

public class Student
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }
}

public class Enrollment
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public Student Student { get; set; }

    public Course Course { get; set; }
}


// ================= DB CONTEXT =================

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Course> Courses { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<Enrollment> Enrollments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Enrollment>()
            .HasIndex(e => new { e.StudentId, e.CourseId })
            .IsUnique();
    }
}


// ================= COURSE CONTROLLER =================

[ApiController]
[Route("api/courses")]
public class CourseController : ControllerBase
{
    private readonly AppDbContext db;

    public CourseController(AppDbContext context)
    {
        db = context;
    }

    [HttpGet]
    public IActionResult GetCourses()
    {
        return Ok(db.Courses.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetCourse(int id)
    {
        var course = db.Courses.Find(id);

        if (course == null)
            return NotFound();

        return Ok(course);
    }

    [HttpPost]
    public IActionResult AddCourse(Course course)
    {
        db.Courses.Add(course);
        db.SaveChanges();

        return Ok(course);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCourse(int id, Course course)
    {
        if (id != course.Id)
            return BadRequest();

        db.Entry(course).State = EntityState.Modified;
        db.SaveChanges();

        return Ok(course);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCourse(int id)
    {
        var course = db.Courses.Find(id);

        if (course == null)
            return NotFound();

        db.Courses.Remove(course);
        db.SaveChanges();

        return Ok();
    }
}


// ================= STUDENT CONTROLLER =================

[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
    private readonly AppDbContext db;

    public StudentController(AppDbContext context)
    {
        db = context;
    }

    [HttpGet]
    public IActionResult GetStudents()
    {
        return Ok(db.Students.ToList());
    }

    [HttpPost]
    public IActionResult AddStudent(Student student)
    {
        db.Students.Add(student);
        db.SaveChanges();

        return Ok(student);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, Student student)
    {
        if (id != student.Id)
            return BadRequest();

        db.Entry(student).State = EntityState.Modified;
        db.SaveChanges();

        return Ok(student);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        var student = db.Students.Find(id);

        if (student == null)
            return NotFound();

        db.Students.Remove(student);
        db.SaveChanges();

        return Ok();
    }
}


// ================= ENROLLMENT CONTROLLER =================

[ApiController]
[Route("api/enrollments")]
public class EnrollmentController : ControllerBase
{
    private readonly AppDbContext db;

    public EnrollmentController(AppDbContext context)
    {
        db = context;
    }

    [HttpGet]
    public IActionResult GetEnrollments()
    {
        var data = db.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .ToList();

        return Ok(data);
    }

    [HttpPost]
    public IActionResult Enroll(Enrollment enrollment)
    {
        var exists = db.Enrollments
            .Any(e => e.StudentId == enrollment.StudentId &&
                      e.CourseId == enrollment.CourseId);

        if (exists)
            return BadRequest("Student already enrolled");

        enrollment.EnrollmentDate = DateTime.Now;

        db.Enrollments.Add(enrollment);
        db.SaveChanges();

        return Ok(enrollment);
    }

    [HttpGet("student/{studentId}")]
    public IActionResult GetStudentCourses(int studentId)
    {
        var data = db.Enrollments
            .Where(e => e.StudentId == studentId)
            .Include(e => e.Course)
            .ToList();

        return Ok(data);
    }

    [HttpGet("course/{courseId}")]
    public IActionResult GetCourseStudents(int courseId)
    {
        var data = db.Enrollments
            .Where(e => e.CourseId == courseId)
            .Include(e => e.Student)
            .ToList();

        return Ok(data);
    }
}