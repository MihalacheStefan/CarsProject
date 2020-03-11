using Microsoft.EntityFrameworkCore;
using Domain.Models;


namespace Repository
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options)
        {
           // this.Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS; Initial Catalog=CarsProjectDB;Integrated Security=True")
                .UseLazyLoadingProxies();
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Chassis> Chassiss { get; set; }
        public virtual DbSet<Engine> Engines { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chassis>()
                .HasMany(c => c.Cars)
                .WithOne(e => e.Chassis)
                .IsRequired();

            modelBuilder.Entity<Engine>()
                .HasMany(c => c.Cars)
                .WithOne(e => e.Engine)
                .IsRequired();

        }
    }
}