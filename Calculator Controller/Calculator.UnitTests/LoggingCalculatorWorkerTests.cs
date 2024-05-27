using FakeItEasy;
using FluentAssertions;
using Serilog;
using Xunit;

namespace Calculator
{
    public class LoggingCalculatorWorkerTests
    {
        [Fact]
        public void LoggingCalculatorWorker_Add_Success()
        {
            var logger = A.Fake<ILogger>();
            var worker = new LoggingCalculatorWorker(logger);

            var result = worker.AddIt(2, 2);
            result.Should().Be(4);
            A.CallTo(() => logger.Information("Values: 2, 2 were added. Result was 4")).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void LoggingCalculatorWorker_Divide_Success()
        {
            var logger = A.Fake<ILogger>();
            var worker = new LoggingCalculatorWorker(logger);

            var result = worker.DivideIt(10, 2);
            result.Should().Be(5);
            A.CallTo(() => logger.Information("Values: 10 divided by 2. Result was 5")).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void LoggingCalculatorWorker_Mod_Success()
        {
            var logger = A.Fake<ILogger>();
            var worker = new LoggingCalculatorWorker(logger);

            var result = worker.ModIt(10, 3);
            result.Should().Be(1);
            A.CallTo(() => logger.Information("Values: 10 modded by 3. Result was 1")).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void LoggingCalculatorWorker_Foo_Success()
        {
            var logger = A.Fake<ILogger>();
            var worker = new LoggingCalculatorWorker(logger);

            var result = worker.FooIt("Hello");
            result.Should().Be(5);
            A.CallTo(() => logger.Information("Length of Hello was fetched. Result was 5")).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void LoggingCalculatorWorker_Multiply_Success()
        {
            var logger = A.Fake<ILogger>();
            var worker = new LoggingCalculatorWorker(logger);

            var result = worker.MultiplyIt(2, 3);
            result.Should().Be(6);
            A.CallTo(() => logger.Information("Values: 2, 3 were multiplied. Result was 6")).MustHaveHappenedOnceExactly();
        }
        
        [Fact]
        public void LoggingCalculatorWorker_Subtract_Success()
        {
            var logger = A.Fake<ILogger>();
            var worker = new LoggingCalculatorWorker(logger);

            var result = worker.SubtractIt(10, 3);
            result.Should().Be(7);
            A.CallTo(() => logger.Information("Values: 3 was subtracted from 10. Result was 7")).MustHaveHappenedOnceExactly();
        }
    }
}
