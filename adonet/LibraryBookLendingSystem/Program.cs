using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// EF Core SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=.;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();


// ================= MODELS =================

public class Book
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Author { get; set; }

    public bool IsAvailable { get; set; } = true;

    public ICollection<Loan> Loans { get; set; }
}

public class Member
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public ICollection<Loan> Loans { get; set; }
}

public class Loan
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int MemberId { get; set; }

    public DateTime LoanDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public Book Book { get; set; }

    public Member Member { get; set; }
}


// ================= DB CONTEXT =================

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Book> Books { get; set; }

    public DbSet<Member> Members { get; set; }

    public DbSet<Loan> Loans { get; set; }
}


// ================= BOOK CONTROLLER =================

[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
    private readonly AppDbContext db;

    public BookController(AppDbContext context)
    {
        db = context;
    }

    [HttpGet]
    public IActionResult GetAll()
        => Ok(db.Books.ToList());

    [HttpGet("available")]
    public IActionResult GetAvailable()
        => Ok(db.Books.Where(b => b.IsAvailable).ToList());

    [HttpPost]
    public IActionResult Add(Book book)
    {
        db.Books.Add(book);
        db.SaveChanges();
        return Ok(book);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Book book)
    {
        if (id != book.Id) return BadRequest();

        db.Entry(book).State = EntityState.Modified;
        db.SaveChanges();

        return Ok(book);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var book = db.Books.Find(id);

        if (book == null) return NotFound();

        db.Books.Remove(book);
        db.SaveChanges();

        return Ok();
    }
}


// ================= MEMBER CONTROLLER =================

[ApiController]
[Route("api/members")]
public class MemberController : ControllerBase
{
    private readonly AppDbContext db;

    public MemberController(AppDbContext context)
    {
        db = context;
    }

    [HttpGet]
    public IActionResult GetAll()
        => Ok(db.Members.ToList());

    [HttpPost]
    public IActionResult Add(Member member)
    {
        db.Members.Add(member);
        db.SaveChanges();
        return Ok(member);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Member member)
    {
        if (id != member.Id) return BadRequest();

        db.Entry(member).State = EntityState.Modified;
        db.SaveChanges();

        return Ok(member);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var member = db.Members.Find(id);

        if (member == null) return NotFound();

        db.Members.Remove(member);
        db.SaveChanges();

        return Ok();
    }
}


// ================= LOAN CONTROLLER =================

[ApiController]
[Route("api/loans")]
public class LoanController : ControllerBase
{
    private readonly AppDbContext db;

    public LoanController(AppDbContext context)
    {
        db = context;
    }

    // Borrow Book
    [HttpPost]
    public IActionResult Borrow(int bookId, int memberId)
    {
        var book = db.Books.Find(bookId);

        if (book == null || !book.IsAvailable)
            return BadRequest("Book not available");

        var loan = new Loan
        {
            BookId = bookId,
            MemberId = memberId,
            LoanDate = DateTime.Now
        };

        book.IsAvailable = false;

        db.Loans.Add(loan);
        db.SaveChanges();

        return Ok(loan);
    }

    // Return Book
    [HttpPut("return/{loanId}")]
    public IActionResult Return(int loanId)
    {
        var loan = db.Loans.Find(loanId);

        if (loan == null) return NotFound();

        loan.ReturnDate = DateTime.Now;

        var book = db.Books.Find(loan.BookId);
        book.IsAvailable = true;

        db.SaveChanges();

        return Ok("Returned");
    }

    // All Loans
    [HttpGet]
    public IActionResult GetAll()
        => Ok(db.Loans
            .Include(l => l.Book)
            .Include(l => l.Member)
            .ToList());

    // Overdue Loans
    [HttpGet("overdue")]
    public IActionResult GetOverdue()
        => Ok(db.Loans
            .Include(l => l.Book)
            .Include(l => l.Member)
            .Where(l => l.ReturnDate == null &&
                        l.LoanDate < DateTime.Now.AddDays(-14))
            .ToList());

    // Top 5 Most Borrowed Books
    [HttpGet("top-books")]
    public IActionResult TopBooks()
        => Ok(db.Loans
            .GroupBy(l => l.BookId)
            .OrderByDescending(g => g.Count())
            .Take(5)
            .Select(g => new
            {
                BookId = g.Key,
                Count = g.Count()
            })
            .ToList());

    // Active Loans by Member
    [HttpGet("member/{memberId}")]
    public IActionResult ActiveLoans(int memberId)
        => Ok(db.Loans
            .Include(l => l.Book)
            .Where(l => l.MemberId == memberId && l.ReturnDate == null)
            .ToList());
}