namespace FootballFantasy.Models
{
    /// <summary>
    /// Ez az osztály egy futball játékost reprezentál.
    /// </summary>
    public class Player
    {
        private int jerseyNumber;

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        /// <summary>
        /// Ezen tulajdonságon keresztül a játékos mezszáma állítható.
        /// </summary>
        public int JerseyNumber
        {
            get => jerseyNumber;
            set
            {
                if (value <= 0 || value >= 100)
                {
                    throw new Exception("A mezszám csak 1 és 100 közötti lehet!");
                }

                jerseyNumber = value;
            }
        }
    }
}
