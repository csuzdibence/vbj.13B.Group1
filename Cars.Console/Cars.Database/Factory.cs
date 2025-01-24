using System.Collections.Generic;
using System.Reflection.Emit;

namespace Cars.Database
{
    public class Factory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Headquarters Headquarters { get; set; } // 1-1 kapcsolat
        public List<Car> Cars { get; set; } = new List<Car>(); // 1-N kapcsolat
    }
}
