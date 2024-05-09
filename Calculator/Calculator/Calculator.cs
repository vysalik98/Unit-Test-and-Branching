using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
        public class SimpleCalculator
    {
        public int Add(int first, int second)
        {
            return first + second;
        }

        public int Subtract(int first, int second)
        {
            return first - second;
        }

        public int Multiply(int first, int second)
        {
            return first * second;
        }

        public int Divide(int first, int second)
        {
            if(second != 0)
            {
                return first / second;
            }
            else
            {
                throw new ArgumentException("Cannot divide by zero.", nameof(second));
            }
        }

        public int Mod(int first, int second)
        {
            return first % second;
        }
    }
}
