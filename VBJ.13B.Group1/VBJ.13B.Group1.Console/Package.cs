namespace VBJ._13B.Group1.Console
{
    /// <summary>
    /// Csomag osztály, a futár ezt viheti ki.
    /// </summary>
    public class Package
    {
        // static csomag id
        private static int idIndex = 1;

        public Package()
        {
            ID = idIndex++;
        }

        public int ID { get; }
    }
}
