using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    public class Cat : IMakeSound
    {
        public void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
    }
}
