using Ccps109;
using Xunit;

namespace Ccps109.Tests;

public class Ccps109Tests
{
    [Theory]
    [InlineData(95, "A+")]
    [InlineData(82, "A-")]
    [InlineData(71, "B-")]
    [InlineData(64, "C")]
    [InlineData(40, "F")]
    public void RyersonLetterGradeTests(int input, string expected)
    {
        string actual = RyersonLetterGrade.GetGrade(input);
        Assert.Equal(actual, expected);
    }
}
