using Microsoft.EntityFrameworkCore;
using Webapp1.Model;

namespace Webapp1;

public class DataDbContext : DbContext
{
    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
    {
    }
    
    public DbSet<Attantion> Attantions { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Student> Students { get; set; }


}