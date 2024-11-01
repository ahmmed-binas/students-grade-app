using Microsoft.EntityFrameworkCore;
using SchoolGradesWebApp.Models;

public class YourDbContext : DbContext
{
    public YourDbContext(DbContextOptions<YourDbContext> options) : base(options) { }

    // Define a DbSet for the Students table
    public DbSet<Student> Students { get; set; }
}
