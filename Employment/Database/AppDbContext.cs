using Employment.Models;
using Microsoft.EntityFrameworkCore;

namespace Employment.Database;

public class AppDbContext :DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<Department> departments { get; set; }
    public DbSet<Employee> employees { get; set; }
}