namespace Students.Model.Interfaces
{
    public interface IEncryptService
    {
        string HashPassword(string password);
    }
}
