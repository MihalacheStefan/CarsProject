using Microsoft.EntityFrameworkCore;
using Domain.Models;


namespace Repository
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options)
        {
        }
        
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarUser> CarsUsers { get; set; }
        public virtual DbSet<Chassis> Chassiss { get; set; }
        public virtual DbSet<Engine> Engines { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasIndex(c => c.Brand)
                .IsUnique();

            modelBuilder.Entity<Chassis>()
                .HasMany(c => c.Cars)
                .WithOne(e => e.Chassis)
                .IsRequired();

            modelBuilder.Entity<Chassis>()
                .HasIndex(c => c.CodeNumber)
                .IsUnique();

            modelBuilder.Entity<Engine>()
                .HasMany(c => c.Cars)
                .WithOne(e => e.Engine)
                .IsRequired();

            modelBuilder.Entity<Engine>()
                .HasIndex(e => e.CylindersNumber)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }
    }
}