using Microsoft.AspNetCore.Http;
using Students.Model.Interfaces;
using System.Text;

namespace Students.Model.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private IHttpContextAccessor httpContextAccessor;
        private ITeacherManager teacherManager;
        private IEncryptService encryptService;

        public AuthenticationService(IHttpContextAccessor httpContextAccessor, ITeacherManager teacherManager, IEncryptService encryptService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.teacherManager = teacherManager;
            this.encryptService = encryptService;
        }

        public bool IsLoggedIn => 
            httpContextAccessor.HttpContext.Session.TryGetValue("email", out byte[] _);

        public string EmailAddress
        {
            get 
            {
                // Kikérjük a session-ből az email címet
                httpContextAccessor.HttpContext.Session.TryGetValue("email", out byte[] values);
                if (values is null)
                {
                    return string.Empty;
                }
                // Konvertálás bájt tömbből stringé
                return Encoding.UTF8.GetString(values);
            }
        }

        public void LogOut()
        {
            httpContextAccessor.HttpContext.Session.Clear();
        }

        public bool TryLogIn(string email, string password)
        {
            // Olvassuk be a tanárt
            var teacherInDatabase = teacherManager.GetAll().FirstOrDefault(teacher => teacher.EmailAddress == email);

            // Benne van-e az adatbázisban a tanár
            if (teacherInDatabase is null)
            {
                // Az az eset, ha még nem regisztrált ezzel az email címmel
                return false;
            }

            // Megnézzük az-e a jelszava, amit megadott
            string hashedPassword = encryptService.HashPassword(password);
            if (hashedPassword != teacherInDatabase.Password)
            {
                return false;
            }

            // Létezik-e már a sessionben érték
            if (httpContextAccessor.HttpContext.Session.TryGetValue("email", out byte[] value))
            {
                // Ha a Sessionben létezik egy email cím
                return false;
            }

            // itt már biztosan sikerült a bejelentkezés
            httpContextAccessor.HttpContext.Session.Set("email", Encoding.UTF8.GetBytes(email));

            return true;
        }
    }
}
