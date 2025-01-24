namespace Cars.Database
{
    public class Headquarters
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int FactoryId { get; set; }
        public Factory Factory { get; set; } // 1-1 kapcsolat
    }
}
