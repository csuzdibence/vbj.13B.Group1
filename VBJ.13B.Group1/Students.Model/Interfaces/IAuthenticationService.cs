namespace Students.Model.Interfaces
{
    public interface IAuthenticationService
    {
        // Kijelentkezés
        void LogOut();

        // Bejelentkezés
        bool TryLogIn(string email, string password);

        // Ez egy olyan tulajdonság, ami megmondja, hogy authentikálva vagyunk-e
        bool IsLoggedIn { get; }
    }
}
