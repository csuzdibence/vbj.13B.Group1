namespace Cars.Database
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int FactoryId { get; set; }
        public Factory Factory { get; set; } // 1-N kapcsolat
        public List<CarPart> CarParts { get; set; } = new List<CarPart>(); // N-N kapcsolat
    }
}
