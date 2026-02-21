using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

// Entity
public class Employee
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }
}

// DTO
public class EmployeeDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
}

// DbContext
public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=.;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True");
}

// Program
class Program
{
    static void Main()
    {
        var dto = new EmployeeDTO
        {
            Name = "Arjun",
            Email = "arjun@gmail.com"
        };

        using var db = new AppDbContext();

        // Check duplicate email
        bool exists = db.Employees.Any(e => e.Email == dto.Email);

        if (exists)
        {
            Console.WriteLine("Email already exists");
        }
        else
        {
            var employee = new Employee
            {
                Name = dto.Name,
                Email = dto.Email
            };

            db.Employees.Add(employee);
            db.SaveChanges();

            Console.WriteLine("Success");
        }
    }
}