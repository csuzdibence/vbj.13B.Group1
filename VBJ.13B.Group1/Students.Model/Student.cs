namespace Students.Model
{
    /// <summary>
    /// Ez az osztály egy tanulót reprezentál.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Ez a property a tanuló azonosítóját állítja
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ez a property a tanuló keresztnevét állítja
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Ez a property a tanuló vezetéknevét állítja
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Ez a property a regisztráció dátumát adja meg.
        /// </summary>
        public DateTime DateOfRegistry { get; set; }

        /// <summary>
        /// Ez a property az email címet adja meg
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Ez a property azt állítja, hogy az adott tanulónak valid vagy nem valid az információja
        /// </summary>
        public bool IsValid { get; set; }

        public override string ToString()
        {
            return $"{Id};{FirstName};{LastName};{EmailAddress};{DateOfRegistry};{IsValid}";
        }
    }
}
