using System;
// using NUnit.Framework;
// using FluentAssertions;

using Calculator; 

var foo = new SimpleCalculator();
namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new SimpleCalculator();
            var foo = new SimpleCalculator();

            Console.WriteLine(calculator.Add(12, 12));
            Console.WriteLine(calculator.Subtract(12, 12));
            Console.WriteLine(calculator.Multiply(12, 12));
            Console.WriteLine(calculator.Divide(12, 12));
            Console.WriteLine(calculator.Mod(42, 7));
            
            try
            {
                var result = foo.Divide(12, 0);
            }
            catch (ArgumentException e)
            {
                if (e.ParamName == "Second")
                {
                    Console.WriteLine("Successfully caught ArgumentException for dividing by zero.");
                }
            }
    
        }
    }
}
