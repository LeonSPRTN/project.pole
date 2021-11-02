using Microsoft.EntityFrameworkCore;
using project.pole.Models;
using System.Linq;


namespace project.pole.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ObjectWork> ObjectWorks { get; set; }
        public DbSet<Estimate> Estimates { get; set; }

        public DbSet<SettingEstimate> SettingEstimates { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}
