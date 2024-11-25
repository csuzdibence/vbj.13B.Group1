namespace Students.Model
{
    // StudentManager interface implementálja az IStudentRemovert és a Readert
    public interface IStudentManager : IStudentRemover, IStudentReader
    {
        // plusz definíció
        void Add(Student student);
    }
}
