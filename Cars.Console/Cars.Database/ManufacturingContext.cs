using Microsoft.EntityFrameworkCore;

namespace Cars.Database
{
    public class ManufacturingContext : DbContext
    {
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Headquarters> Headquarters { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<CarPart> CarParts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Manufacturing");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // N-N kapcsolat konfigurálása
            modelBuilder.Entity<CarPart>()
                .HasKey(cp => new { cp.CarId, cp.PartId });

            modelBuilder.Entity<CarPart>()
                .HasOne(cp => cp.Car)
                .WithMany(c => c.CarParts)
                .HasForeignKey(cp => cp.CarId);

            modelBuilder.Entity<CarPart>()
                .HasOne(cp => cp.Part)
                .WithMany(p => p.CarParts)
                .HasForeignKey(cp => cp.PartId);
        }
    }
}
