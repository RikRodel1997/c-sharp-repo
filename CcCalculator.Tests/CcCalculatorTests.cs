namespace CcCalculator.Tests;

public class CcCalculatorTests
{
    [Theory]
    [InlineData("1 + 2", 3)]
    [InlineData("2 - 1", 1)]
    [InlineData("2 * 3", 6)]
    [InlineData("3 / 2", 1)]
    public void SimpleExpressionsTest(string expression, int expected)
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
    [InlineData("5 + 5 * 4 - 4 / 3", 25)]
    [InlineData("(1 + 1 + (3 + 2 * 5 + (4 - 1))) * 5", 90)]
    public void PrecedenceTest(string expression, int expected)
    {
        double actual = Program.Run(expression);
        Assert.Equal(expected, actual);
    }
}
