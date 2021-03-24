using Microsoft.EntityFrameworkCore;

namespace MyClassLibrary.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}
