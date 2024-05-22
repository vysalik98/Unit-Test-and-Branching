using FakeItEasy;
using Xunit;

namespace Calculator
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculator_Add_Success()
        {
            var worker = A.Fake<ICalculatorWorker>();

            // Inject in constructor
            //var calc = new Calculator(worker);

            // Inject via property
            //var calc = new Calculator(new CalculatorWorker());
            //calc.Worker = worker;


            // Inject via method
            var calc = new Calculator(new CalculatorWorker());
            calc.SetWorker(worker);

            calc.Add(2, 2);

            A.CallTo(() => worker.AddIt(2, 2)).MustHaveHappenedOnceExactly();
        }
    }
}
