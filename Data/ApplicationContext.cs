using Microsoft.EntityFrameworkCore;
using project.pole.Models;
using System.Linq;


namespace project.pole.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Object> Objects { get; set; }
        public DbSet<Estimate> Estimates { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}
