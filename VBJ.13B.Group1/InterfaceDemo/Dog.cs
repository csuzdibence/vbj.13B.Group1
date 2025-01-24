namespace InterfaceDemo
{
    /// <summary>
    /// Ez az osztály egy kutyát reprezentál
    /// </summary>
    public class Dog : IMakeSound
    {
        public void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
