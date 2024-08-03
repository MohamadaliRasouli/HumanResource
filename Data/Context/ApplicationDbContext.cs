using HumanResource.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Data.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Person> Persons { get; set; }

    
}