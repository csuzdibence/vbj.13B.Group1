﻿using Students.Model.Interfaces;

namespace Students.Model.Implementations
{
    public class DatabaseTeacherManager : ITeacherManager
    {
        private StudentDbContext dbContext;

        public DatabaseTeacherManager(StudentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Teacher teacher)
        {
            // Adatbázisba beszúrás
            dbContext.Teachers.Add(teacher);
            dbContext.SaveChanges();
        }

        public IQueryable<Teacher> GetAll()
        {
            return dbContext.Teachers.AsQueryable();
        }
    }
}
