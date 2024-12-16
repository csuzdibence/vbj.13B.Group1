namespace Students.Model
{
    public class Teacher
    {
        // Elsődleges kulcs
        public int Id { get; set; }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public ICollection<Student> Students { get; } = new List<Student>();
    }
}
