using Microsoft.EntityFrameworkCore;

namespace Students.Model
{
    public class StudentDbContext : DbContext
    {
        // Ez egy táblát reprezentál
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1 darab kapcsolat Teacher - Student 1-N kapcsolat

            //// Egy tanárnak
            //modelBuilder.Entity<Teacher>()
            //    // Lehetnek diákjai
            //    .HasMany(teacher => teacher.Students)
            //    // Minden diáknak egy tanára van
            //    .WithOne(student => student.Teacher)
            //    // Van egy idegen kulcsa, méghozzá a TeacherId
            //    .HasForeignKey(student => student.TeacherId)
            //    // Kötelező megadni
            //    .IsRequired();
        }

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
