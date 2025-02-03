namespace UnitTest.Practice
{
    internal class Calculator
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        // 1,5 - 2 -> 2,25
        // 0 -> 3
        // 1 -> 16

        public double PowerBy(double number, int multiplier)
        {
            return Math.Pow(number, multiplier);
        }
    }
}
