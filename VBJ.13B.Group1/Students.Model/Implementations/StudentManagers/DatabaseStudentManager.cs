
namespace Students.Model.Implementations.StudentManagers
{
    public class DatabaseStudentManager : IStudentManager
    {
        // Dependency Injection / Konstruktor Injection
        private StudentDbContext dbContext;
        public DatabaseStudentManager(StudentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Student student)
        {
            student.Id = 0;
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
        }

        public List<Student> ReadStudents()
        {
            // Mindent eltárolsz memóriában
            return dbContext.Students.ToList();

            //IQueryable<Student> query = dbContext.Students.AsQueryable();
            //query.Where(x => x.Password == "kiscica");
            //return query.ToList();
        }

        public void RemoveStudent(Student student)
        {
            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
        }
    }
}
