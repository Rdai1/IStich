using Microsoft.EntityFrameworkCore;

namespace IStichIt.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Services> Services { get; set; }
        public DbSet<Service> Service { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Services>()
                .HasKey(s => new { s.Category });

            modelBuilder.Entity<Services>()
                .HasMany(s => s.ServicesList)
                .WithOne()
                .HasForeignKey(s => s.Category);

            base.OnModelCreating(modelBuilder);
        }
    }
}
