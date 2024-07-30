using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Person> Persons { get; set; }

    
}