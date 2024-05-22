// namespace LoggingCalculatorWorker.Tests;

// public class UnitTest1
// {
//     [Fact]
//     public void Test1()
//     {

//     }
// }
using System;
using FluentAssertions;
using Xunit;
using Serilog;
using FakeItEasy;

namespace  Calculator
{
    public class LoggingCalculatorWorkerTests
    {
        [Fact]
        public void LoggingCalculatorWorker_AddIt_WithPositiveNumbers_ReturnsPostiveSum()
        {
            // Arrange
            var _logger = A.Fake<ILogger>();
            var calc = new LoggingCalculatorWorker(_logger);

            // Act
            var result = calc.AddIt(2, 2);

            // Assert
            result.Should().Be(4);
            A.CallTo(() => _logger.Information("Values: 2, 2 were added. Result was 4")).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void LoggingCalculatorWorker_AddIt_WithNegativeNumbers_ReturnsNegativeSum()
        {
            // Arrange
            var _logger = A.Fake<ILogger>();
            var calc = new LoggingCalculatorWorker(_logger);

            // Act
            var result = calc.AddIt(-12, -12);

            // Assert
            result.Should().Be(-24);
            A.CallTo(() => _logger.Information("Values: -12, -12 were added. Result was -24")).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void LoggingCalculatorWorker_SubtractIt_ReturnsValidDifference()
        {
            // Arrange
            var logger = A.Fake<ILogger>();
            var calc = new LoggingCalculatorWorker(logger);

            // Act
            var result = calc.SubtractIt(12, 2);

            // Assert
            result.Should().Be(10);
            A.CallTo(() => logger.Information("Values: 2 was subtracted from 12. Result was 10")).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void LoggingCalculatorWorker_MultiplyIt_WithPositiveNumbers_ReturnsPostitiveProduct()
        {
            // Arrange
            var logger = A.Fake<ILogger>();
            var calc = new LoggingCalculatorWorker(logger);

            // Act
            var result = calc.MultiplyIt(2, 3);

            // Assert
            result.Should().Be(6);
            A.CallTo(() => logger.Information("Values: 2, 3 were multiplied. Result was 6")).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void LoggingCalculatorWorker_MultiplyIt_WithNegativeNumbers_ReturnsPostitiveProduct()
        {
            // Arrange
            var logger = A.Fake<ILogger>();
            var calc = new LoggingCalculatorWorker(logger);

            // Act
            var result = calc.MultiplyIt(-2, -3);

            // Assert
            result.Should().Be(6);
            A.CallTo(() => logger.Information("Values: -2, -3 were multiplied. Result was 6")).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void LoggingCalculatorWorker_DivideIt_ReturnsValidValue()
        {
            // Arrange
            var logger = A.Fake<ILogger>();
            var calc = new LoggingCalculatorWorker(logger);

            // Act
            var result = calc.DivideIt(12, 3);

            // Assert
            result.Should().Be(4);
            A.CallTo(() => logger.Information("Values: 12 divided by 3. Result was 4")).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void LoggingCalculatorWorker_ModIt_ReturnsValidValue()
        {
            // Arrange
            var logger = A.Fake<ILogger>();
            var calc = new LoggingCalculatorWorker(logger);

            // Act
            var result = calc.ModIt(15, 7);

            // Assert
            result.Should().Be(1);
            A.CallTo(() => logger.Information("Values: 15 mod 7. Result was 1")).MustHaveHappenedOnceExactly();
        }

       
        [Theory,
         InlineData(12, 0),
         InlineData(0, 0)]
        public void LoggingCalculatorWorker_DivideIt_ThrowsException_WhenDenominatorIsZero(int numerator, int denominator)
        {
            // Arrange
            var logger = A.Fake<ILogger>();
            var calc = new LoggingCalculatorWorker(logger);

            // Act
            Action action = () => calc.DivideIt(numerator, denominator);

            // Assert
            action.Should().Throw<DivideByZeroException>();
            A.CallTo(() => logger.Information(A<string>._)).MustNotHaveHappened();
        }

        [Theory,
         InlineData(12, 0),
         InlineData(0, 0)]
        public void LoggingCalculatorWorker_ModIt_ThrowsException_WhenDenominatorIsZero(int numerator, int denominator)
        {
            // Arrange
            var logger = A.Fake<ILogger>();
            var calc = new LoggingCalculatorWorker(logger);

            // Act
            Action action = () => calc.ModIt(numerator, denominator);

            // Assert
            action.Should().Throw<DivideByZeroException>();
            A.CallTo(() => logger.Information(A<string>._)).MustNotHaveHappened();
        }

        [Theory,
         InlineData(null),
         InlineData(""),
         InlineData("  ")]
        public void LoggingCalculatorWorker_FooIt_NullOrWhitespaceThrows(string bar)
        {
            // Arrange
            var logger = A.Fake<ILogger>();
            var calc = new LoggingCalculatorWorker(logger);

            // Act
            Action action = () => calc.FooIt(bar);

            // Assert
            action.Should().Throw<ArgumentException>().Which.ParamName.Should().Be("bar");
            A.CallTo(() => logger.Information(A<string>._)).MustNotHaveHappened();
        }
    }
}
