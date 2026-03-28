using Ccps109;
using Xunit;

namespace Ccps109.Tests;

public class Ccps109Tests
{
    [Theory]
    [InlineData(45, "F")]
    [InlineData(62, "C-")]
    [InlineData(89, "A")]
    [InlineData(107, "A+")]
    public void RyersonLetterGradeTest(int input, string expected)
    {
        string actual = RyersonLetterGrade.GetGrade(input);
        Assert.Equal(actual, expected);
    }

    [Theory]
    [InlineData(new int[] { }, true)]
    [InlineData(new int[] { -5, 10, 99, 123456 }, true)]
    [InlineData(new int[] { 2, 3, 3, 4, 5 }, false)]
    [InlineData(new int[] { -99 }, true)]
    [InlineData(new int[] { 4, 5, 6, 7, 3, 7, 9 }, false)]
    [InlineData(new int[] { 1, 1, 1, 1 }, false)]
    public void AscendingListTest(int[] input, bool expected)
    {
        bool actual = AscendingList.IsAscending(input);
        Assert.Equal(actual, expected);
    }
}
