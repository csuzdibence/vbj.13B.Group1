namespace UnitTest.Practice
{
    internal class Calculator
    {
        private IAdder adder;
        public Calculator(IAdder adder)
        {
            this.adder = adder;
        }

        public int Add(int x, int y)
        {
            // Tovább delegálja a kérést
            return adder.Add(x, y);
        }

        // 1,5 - 2 -> 2,25
        // 0 -> 3
        // 1 -> 16

        public double PowerBy(double number, int multiplier)
        {
            return Math.Pow(number, multiplier);
        }

        public int Min(int[] nums)
        {
            int min = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < min)
                {
                    min = nums[i];
                }
            }
            return min;
        }
    }
}
