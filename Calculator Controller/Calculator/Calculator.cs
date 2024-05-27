namespace Calculator
{
    public class Calculator : ICalculator
    {
        private readonly ICalculatorWorker _calculatorWorker;

        // Inject in construtor
        public Calculator(ICalculatorWorker calculatorWorker)
        {
            _calculatorWorker = calculatorWorker;
        }

        public int Add(int first, int second)
        {
            return _calculatorWorker.AddIt(first, second);
        }

        public int Subtract(int first, int second)
        {
            return _calculatorWorker.SubtractIt(first, second);
        }

        public int Multiply(int first, int second)
        {
            return _calculatorWorker.MultiplyIt(first, second);
        }

        public int Divide(int first, int second)
        {
            return _calculatorWorker.DivideIt(first, second);
        }

        public int Mod(int first, int second)
        {
            return _calculatorWorker.ModIt(first, second);
        }

        public int Foo(string bar)
        {
            return _calculatorWorker.FooIt(bar);
        }
    }
}
