using System;
using Calculator;
using FluentAssertions;

namespace Calculator.Tests;

public class CalculatorTests
{
    [Theory]
    [InlineData(5, 3, 8)] // 5 + 3 = 8
    [InlineData(10, 2, 12)] // 10 + 2 = 12
    [InlineData(-5, 3, -2)] // -5 + 3 = -2
    [InlineData(-100, -200, -300)] // -100 + (-200) = -300
    public void AddTest(int first, int second, int expected)
    {
        var calculator = new SimpleCalculator();
        var result = calculator.Add(first, second);
        result.Should().Be(expected);
    }
    [Theory]
    [InlineData(8, 3, 5)] // 8 - 3 = 5
    [InlineData(15, 7, 8)] // 15 - 7 = 8
    [InlineData(-5, -3, -2)] // -5 - (-3) = -2
    [InlineData(-50, 20, -70)] // -50 - 20 = -70
    public void SubtractTest(int first, int second, int expected)
    {
        var calculator = new SimpleCalculator();
        var result = calculator.Subtract(first, second);
        result.Should().Be(expected);
    }
    [Theory]
    [InlineData(1, 2, 2)] // 1 * 2 = 2
    [InlineData(2, 3, 6)] // 2 * 3 = 6
    [InlineData(-3, -10, 30)]  // -3 * -10 = 30
    [InlineData(-10, 10, -100)] // -10 * 10 = -100
    [InlineData(8, 0, 0)] // 8 * 0 = 0
    public void MultiplyTest(int first, int second, int expected)
    {
        var calculator = new SimpleCalculator();
        var result = calculator.Multiply(first, second);
        result.Should().Be(expected);
    }
    [Theory]
    [InlineData(10, 5, 2)] // 10 / 5 = 2
    [InlineData(0, 8, 0)] // 0 / 8 = 0
    [InlineData(-10, 5, -2)] // -10 / 5 = -2
    [InlineData(-400, -100, 4)] // -400 / -100 = 4
    public void DivideTest(int first, int second, int expected)
    {
        var calculator = new SimpleCalculator();
        var result = calculator.Divide(first, second);
        result.Should().Be(expected);
    }
    [Theory]
    [InlineData(9, 3, 0)] // 9 % 3 = 0
    [InlineData(12, 5, 2)] // 12 % 5 = 2
    [InlineData(-20, 3, -2)] // -20 % 3 = -2
    [InlineData(-100, -300, -100)] //  -100 % -300 = -100
    public void ModTest(int first, int second, int expected)
    {
        var calculator = new SimpleCalculator();
        var result = calculator.Mod(first, second);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(12, 0)]
    [InlineData(0, 0)]
    [InlineData(-30, 0)]
    public void DivideByZeroTest(int first, int second)
    {
        // Arrange
        var calculator = new SimpleCalculator();

        // Act & Assert
        Action action = () => calculator.Divide(first, second);
        action.Should().Throw<ArgumentException>()
    .WithMessage("Cannot divide by zero. (Parameter 'second')");
    }
}


