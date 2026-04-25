namespace CcCalculator.Tests;

public class CcCalculatorTests
{
    [Theory]
    [InlineData("1 + 2", 3)]
    [InlineData("22 - 11", 11)]
    [InlineData("2 * 3", 6)]
    [InlineData("3 / 2", 1.5)]
    public void SimpleExpressionsTest(string expression, double expected)
    {
        double actual = Program.Run(expression);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("1 + 1 * 5", 6)]
    [InlineData("(1 + 1) * 5", 10)]
    [InlineData("(1 + (1 + 3)) * 5", 25)]
    [InlineData("(1 + 1 * 6) * 5", 35)]
    [InlineData("(1 * 2) - (3 * 4)", -10)]
    [InlineData("5 + 5 * 4 - 4 / 5", 24.2)]
    [InlineData("(1 + 1 + (3 + 2 * 5 + (4 - 1))) * 5", 90)]
    public void PrecedenceTest(string expression, double expected)
    {
        double actual = Program.Run(expression);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("sin(1 + 5)", -0.279415498)]
    [InlineData("1 + 2 - sin(5)", 3.95892427)]
    [InlineData("cos(1 + 5)", 0.960170287)]
    [InlineData("2 - 1 + cos(5)", 1.28366219)]
    [InlineData("tan(1 + 5)", -0.291006191)]
    [InlineData("3 * 4 - tan(5)", 15.38051501)]
    [InlineData("tan(sin(1) + cos((1 + 2) * 3))", -0.0697721681)]
    public void FunctionsTest(string expression, double expected)
    {
        double actual = Program.Run(expression);
        Assert.Equal(expected, actual, 8);
    }
}
