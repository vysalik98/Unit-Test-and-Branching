namespace Calculator
{
    public interface ICalculator
    {
        int Add(int first, int second);

        int Subtract(int first, int second);

        int Multiply(int first, int second);

        int Divide(int first, int second);

        int Mod(int first, int second);

        int Foo(string bar);
    }
}
