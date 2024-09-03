using Microsoft.EntityFrameworkCore;
using IStitch.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IStitch.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<ServiceType> ServiceType { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<CustomerItems> CusItems{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Define the primary Key
            modelBuilder.Entity<ServiceType>()
                .HasKey(s => new { s.Category });

            //define the many to many relationship
            modelBuilder.Entity<ServiceType>()
                .HasMany(s => s.ServicesList)
                .WithOne()
                .HasForeignKey(s => s.Category);

            base.OnModelCreating(modelBuilder);
        }
    }
}
