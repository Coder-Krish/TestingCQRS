using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestingLibrary.Models;

namespace TestingLibrary.DataAccess;

public class PersonDbContext:DbContext
{
    public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
    {
            
    }
    public DbSet<Person> Persons { get; set; }
    public DbSet<PersonDetails> PersonDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var connectionString = configuration.GetConnectionString("AppDb");
        optionsBuilder.UseSqlServer(connectionString);
    }
}