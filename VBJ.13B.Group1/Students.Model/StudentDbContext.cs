using Microsoft.EntityFrameworkCore;

namespace Students.Model
{
    public class StudentDbContext : DbContext
    {
        // Ez egy táblát reprezentál
        public DbSet<Student> Students { get; set; }

        // Örökölve van a DbContext osztály -> EF
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Ha még nincs konfigurálva az adatbázis
            if (!optionsBuilder.IsConfigured)
            {
                // akkor megadjuk a connection stringet (első paraméter: szerver, második: adatbázis név
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=StudentDatabase");
            }
        }
    }
}
