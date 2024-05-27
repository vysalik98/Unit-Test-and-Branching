using System;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CalculatorAPIs.Controllers.v1
{
    public class CalculatorControllerTests
    {
        [Fact]
        public void CalculatorController_Add_Success()
        {
            var calculator = A.Fake<Calculator.ICalculator>();
            A.CallTo(() => calculator.Add(2, 2)).Returns(4);
            var controller = new CalculatorController(calculator);

            var request = new CalculatorRequest { First = 2, Second = 2 };
            var result = controller.Add(request) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().Be(4);
        }

        [Fact]
        public void CalculatorController_Subtract_Success()
        {
            var calculator = A.Fake<Calculator.ICalculator>();
            A.CallTo(() => calculator.Subtract(2, 2)).Returns(0);
            var controller = new CalculatorController(calculator);

            var request = new CalculatorRequest { First = 2, Second = 2 };
            var result = controller.Subtract(request) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().Be(0);
        }

        [Fact]
        public void CalculatorController_Multiply_Success()
        {
            var calculator = A.Fake<Calculator.ICalculator>();
            A.CallTo(() => calculator.Multiply(2, 2)).Returns(4);
            var controller = new CalculatorController(calculator);

            var request = new CalculatorRequest { First = 2, Second = 2 };
            var result = controller.Multiply(request) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().Be(4);
        }

        [Fact]
        public void CalculatorController_Divide_Success()
        {
            var calculator = A.Fake<Calculator.ICalculator>();
            A.CallTo(() => calculator.Divide(2, 2)).Returns(1);
            var controller = new CalculatorController(calculator);

            var request = new CalculatorRequest { First = 2, Second = 2 };
            var result = controller.Divide(request) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().Be(1);
        }

        [Fact]
        public void CalculatorController_Mod_Success()
        {
            var calculator = A.Fake<Calculator.ICalculator>();
            A.CallTo(() => calculator.Mod(2, 2)).Returns(0);
            var controller = new CalculatorController(calculator);

            var request = new CalculatorRequest { First = 2, Second = 2 };
            var result = controller.Divide(request) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().Be(0);
        }

        [Fact]
        public void CalculatorController_GetStatus_Success()
        {
            var calculator = A.Fake<Calculator.ICalculator>();
            var controller = new CalculatorController(calculator);

            var result = controller.GetStatus() as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().Be("We're all good");
        }

    }
}
