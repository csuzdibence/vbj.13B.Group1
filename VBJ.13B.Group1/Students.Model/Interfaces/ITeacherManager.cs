namespace Students.Model.Interfaces
{
    public interface ITeacherManager
    {
        void Add(Teacher teacher);
        IQueryable<Teacher> GetAll();
    }
}
