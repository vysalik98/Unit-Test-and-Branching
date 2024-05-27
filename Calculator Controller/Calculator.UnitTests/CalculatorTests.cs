using FakeItEasy;
using Xunit;
using System;


namespace Calculator
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculator_Add_Success()
        {
            var worker = A.Fake<ICalculatorWorker>();

            // Inject in constructor
            var calc = new Calculator(worker);

            calc.Add(2, 2);

            A.CallTo(() => worker.AddIt(2, 2)).MustHaveHappenedOnceExactly();
        }
        [Fact]
        public void Calculator_Subtract_Success()
        {
            var worker = A.Fake<ICalculatorWorker>();

            // Inject in constructor
            var calc = new Calculator(worker);

            calc.Subtract(2, 2);

            A.CallTo(() => worker.SubtractIt(2, 2)).MustHaveHappenedOnceExactly();
        }
        [Fact]
        public void Calculator_Multiply_Success()
        {
            var worker = A.Fake<ICalculatorWorker>();

            // Inject in constructor
            var calc = new Calculator(worker);

            calc.Multiply(2, 2);

            A.CallTo(() => worker.MultiplyIt(2, 2)).MustHaveHappenedOnceExactly();
        }
        [Fact]
        public void Calculator_Divide_Success()
        {
            var worker = A.Fake<ICalculatorWorker>();

            // Inject in constructor

            var calc = new Calculator(worker);

            calc.Divide(2, 2);

            A.CallTo(() => worker.DivideIt(2, 2)).MustHaveHappenedOnceExactly();
        }
        [Fact]
        public void Divide_By_Zero_Throws_Exception()
        {
            var worker = A.Fake<ICalculatorWorker>();

            var argumentException = new ArgumentException("Cannot be 0.", "second");
            A.CallTo(() => worker.DivideIt(A<int>._, 0)).Throws(argumentException);

            var exception = Assert.Throws<ArgumentException>(() => worker.DivideIt(10, 0));

            Assert.Equal("second", exception.ParamName);
            Assert.StartsWith("Cannot be 0.", exception.Message);
        }

        [Fact]
        public void Calculator_Mod_Success()
        {
            var worker = A.Fake<ICalculatorWorker>();

            // Inject in constructor
            var calc = new Calculator(worker);

            calc.Mod(2, 2);

            A.CallTo(() => worker.ModIt(2, 2)).MustHaveHappenedOnceExactly();
        }
        [Fact]
        public void Calculator_Foo_Success()
        {
            var worker = A.Fake<ICalculatorWorker>();

            // Inject in constructor
            var calc = new Calculator(worker);

            calc.Foo("bar");

            A.CallTo(() => worker.FooIt("bar")).MustHaveHappenedOnceExactly();
        }

    }
}
