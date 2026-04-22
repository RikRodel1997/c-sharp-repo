namespace CcCalculator.Tests;

public class CcCalculatorTests
{
    [Theory]
    [InlineData("1 + 2", 3)]
    [InlineData("2 - 1", 1)]
    [InlineData("2 * 3", 6)]
    [InlineData("3 / 2", 1.5)]
    public void SimpleExpressionsTest(string expression, double expected)
    {
        double actual = Program.Run(expression);
        Assert.Equal(expected, actual);
    }
}
