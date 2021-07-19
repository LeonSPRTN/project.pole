using Microsoft.EntityFrameworkCore;
using project.pole.Models;
using System.Linq;


namespace project.pole.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<User>().HasData(new User { Login = "admin", Password = "admin" });
        }

    }
}
