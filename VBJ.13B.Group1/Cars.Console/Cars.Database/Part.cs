namespace Cars.Database
{
    public class Part
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CarPart> CarParts { get; set; } = new List<CarPart>(); // N-N kapcsolat
    }
}
