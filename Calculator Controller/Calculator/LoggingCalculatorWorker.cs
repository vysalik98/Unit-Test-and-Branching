using EnsureThat;
using Serilog;

namespace Calculator
{
    public class LoggingCalculatorWorker : ICalculatorWorker
    {
        private readonly ILogger _logger;

        public LoggingCalculatorWorker(ILogger logger)
        {
            _logger = logger;
        }

        public int AddIt(int first, int second)
        {
            var result = first + second;
            _logger.Information($"Values: {first}, {second} were added. Result was {result}");
            return result;
        }

        public int DivideIt(int first, int second)
        {
            Ensure.That(second, nameof(second)).IsNot(0);
            var result = first / second;
            _logger.Information($"Values: {first} divided by {second}. Result was {result}");
            return result;
        }

        public int ModIt(int first, int second)
        {
            Ensure.That(second, nameof(second)).IsNot(0);
            var result = first % second;
            _logger.Information($"Values: {first} modded by {second}. Result was {result}");
            return result;
        }

        public int FooIt(string bar)
        {
            Ensure.That(bar, nameof(bar)).IsNotNullOrWhiteSpace();
            var result = bar.Length;
            _logger.Information($"Length of {bar} was fetched. Result was {result}");
            return result;
        }

        public int MultiplyIt(int first, int second)
        {
            var result = first * second;
            _logger.Information($"Values: {first}, {second} were multiplied. Result was {result}");
            return result;
        }

        public int SubtractIt(int first, int second)
        {
            var result = first - second;
            _logger.Information($"Values: {second} was subtracted from {first}. Result was {result}");
            return result;
        }
    }
}
