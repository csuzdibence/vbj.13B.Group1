using Students.Model.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Students.Model.Implementations
{
    public class SHA256EncryptService : IEncryptService
    {
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordInBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashedBytes = sha256.ComputeHash(passwordInBytes);
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
