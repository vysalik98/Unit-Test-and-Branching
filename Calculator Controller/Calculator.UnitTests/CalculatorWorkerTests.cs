using FluentAssertions;
using Xunit;
using System;

namespace Calculator
{
    public class CalculatorWorkerTests
    {
        [Fact]
        public void CalculatorWorker_AddIt_withPositiveNumbers_Success()
        {
            var calc = new CalculatorWorker();
            var result = calc.AddIt(4, 4);
            result.Should().Be(8);
        }
        [Fact]
        public void CalculatorWorker_AddIt_withNegativeNumbers_Success()
        {
            var calc = new CalculatorWorker();
            var result = calc.AddIt(-4, -10);
            result.Should().Be(-14);
        }
        [Fact]
        public void CalculatorWorker_SubtractIt_withPositiveNumbers_Success()
        {
            var calc = new CalculatorWorker();
            var result = calc.SubtractIt(10, 3);
            result.Should().Be(7);
        }
        [Fact]
        public void CalculatorWorker_SubtractIt_withNegativeNumbers_Success()
        {
            var calc = new CalculatorWorker();
            var result = calc.SubtractIt(-8, -3);
            result.Should().Be(-5);
        }
        [Theory]
        [InlineData(1, 2, 2)] // 1 * 2 = 2
        [InlineData(-20, 20, -400)] // -20 * 20 = -400
        [InlineData(10, 0, 0)] // 10 * 0 = 0
        public void CalculatorWorker_MultiplyIt_Success(int first, int second, int expected)
        {
            var calculator = new CalculatorWorker();
            var result = calculator.MultiplyIt(first, second);
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(36, 6, 6)] // 36 / 6 = 6
        [InlineData(-16, 2, -8)] // -16 / 2 = -8
        [InlineData(-500, -100, 5)] // -500 / -100 = 5
        public void CalculatorWorker_DivideIt_Success(int first, int second, int expected)
        {
            var calculator = new CalculatorWorker();
            var result = calculator.DivideIt(first, second);
            result.Should().Be(expected);
        }

        [Fact]
        public void CalculatorWorker_DivideIt_ThrowsWhenDenominatorIsZero()
        {
            var calc = new CalculatorWorker();
            Action action = () => calc.DivideIt(12, 0);
            action.Should().Throw<ArgumentException>().Which.ParamName.Should().Be("second");
        }

        [Theory]
        [InlineData(16, 4, 0)] // 16 % 4 = 0
        [InlineData(16, 3, 1)] // 16 % 3 = 1
        [InlineData(-100, -400, -100)] //  -100 % -400 = -100
        public void CalculatorWorker_ModIt_Success(int first, int second, int expected)
        {
            var calculator = new CalculatorWorker();
            var result = calculator.ModIt(first, second);
            result.Should().Be(expected);
        }

        [Fact]
        public void CalculatorWorker_ModIt_ThrowsWhenDenominatorIsZero()
        {
            var calc = new CalculatorWorker();
            Action action = () => calc.ModIt(12, 0);
            action.Should().Throw<ArgumentException>().Which.ParamName.Should().Be("second");
        }

        [Theory,
        InlineData(null),
        InlineData(""),
        InlineData("  ")]
        public void CalculatorWorker_FooIt_NullOrWhitespaceThrows(string bar)
        {
            var calc = new CalculatorWorker();
            Action action = () => calc.FooIt(bar);
            action.Should().Throw<ArgumentException>().Which.ParamName.Should().Be("bar");
        }
    }
}
