namespace VBJ._13B.Group1.OOPGyakorlo1
{
    public class Prisoner
    {
        public Prisoner(string name, int id)
        {
            Name = name;
            ID = id;
            Smartness = new Random().Next(1, 101);
        }

        public string Name { get; }
        public int ID { get; }

        public int Smartness { get; set; }

        public string PrisonerText => $"{Name} #{ID}";
    }
}
