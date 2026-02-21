using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

// Entity with RowVersion for concurrency
public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Salary { get; set; }

    [Timestamp] // Concurrency token
    public byte[] RowVersion { get; set; }
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
        int employeeId = 1;
        decimal newSalary = 50000;

        // RowVersion received from client (example)
        byte[] rowVersion = GetRowVersionFromClient();

        using var db = new AppDbContext();

        var employee = new Employee
        {
            Id = employeeId,
            Salary = newSalary,
            RowVersion = rowVersion
        };

        db.Employees.Attach(employee);
        db.Entry(employee).Property(e => e.Salary).IsModified = true;
        db.Entry(employee).Property(e => e.RowVersion).OriginalValue = rowVersion;

        try
        {
            db.SaveChanges();
            Console.WriteLine("Success");
        }
        catch (DbUpdateConcurrencyException)
        {
            Console.WriteLine("Concurrency Exception");
        }
    }

    // Example method to simulate RowVersion input
    static byte[] GetRowVersionFromClient()
    {
        return new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 };
    }
}