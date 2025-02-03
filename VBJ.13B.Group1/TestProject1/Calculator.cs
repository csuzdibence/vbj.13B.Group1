using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class Calculator
    {
        public double PowerBy(double amount, double power)
        {
            return Math.Pow(amount * amount, power);
        }
    }
}
