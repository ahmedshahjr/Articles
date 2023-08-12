using Consumer.Models;
using Microsoft.EntityFrameworkCore;

namespace Consumer.Data
{
    public class MainDbContext:DbContext
    {
     //   public DbSet<CustomerData> customers { get; set; }
        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
