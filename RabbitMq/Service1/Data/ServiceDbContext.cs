using Microsoft.EntityFrameworkCore;
using Service1.Models;

namespace Service1.Data
{
    
    public class ServiceDbContext : DbContext
    {
        public DbSet<Customer> customers { get; set; }
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
