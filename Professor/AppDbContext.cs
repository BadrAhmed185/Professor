using Microsoft.EntityFrameworkCore;
using Professor.Models;

namespace Professor
{
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        // Constructor accepting DbContextOptions
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Optional: Customize model configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example: Configure Student entity
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.Id); // Assuming Student has an Id property
                entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
                // Add more configuration as needed
            });
        }
    }
}