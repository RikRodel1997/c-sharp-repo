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
        Assert.Equal(expected, actual);
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
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, true, new int[] { 1, 5, 2, 6, 3, 7, 4, 8 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, false, new int[] { 5, 1, 6, 2, 7, 3, 8, 4 })]
    [InlineData(new int[] { }, true, new int[] { })]
    [InlineData(new string[] { "bob", "jack" }, true, new string[] { "bob", "jack" })]
    [InlineData(new string[] { "bob", "jack" }, false, new string[] { "jack", "bob" })]
    public void RiffleShuffleKerfuffleTest<T>(T[] input, bool outShuffle, T[] expected)
    {
        T[] actual = RiffleShuffleKerfuffle.Riffle(input, outShuffle);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(8, false)]
    [InlineData(1357975313579, true)]
    [InlineData(42, false)]
    [InlineData(71358, false)]
    [InlineData(0, false)]
    public void EvenTheOddsTest<T>(long n, bool expected)
    {
        bool actual = EvenTheOdds.OnlyOddDigits(n);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, true)]
    [InlineData(101, true)]
    [InlineData(98053, true)]
    [InlineData(777888999, false)]
    [InlineData(1056, false)]
    [InlineData(675409820, false)]
    public void CyclopsNumbersTest<T>(int n, bool expected)
    {
        bool actual = CyclopsNumbers.IsCyclops(n);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] { 3, 5, 5, 2, 2, 3 }, true)]
    [InlineData(new int[] { 4, 4 }, true)]
    [InlineData(new int[] { }, true)]
    [InlineData(new int[] { 2, 6 }, false)]
    [InlineData(new int[] { 5, 2, 2, 3, 4, 5 }, false)]
    [InlineData(new int[] { 4, 3, 3, 1 }, false)]
    public void DominoCycleTest(int[] flat, bool expected)
    {
        // because we can't pass tuples into InlineDate
        (int, int)[] tiles = [.. Enumerable.Range(0, flat.Length / 2).Select(i => (flat[i * 2], flat[i * 2 + 1]))];

        bool actual = DominoCycle.IsDominoCycle(tiles);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("y", "y")]
    [InlineData("bb", "b")]
    [InlineData("rybyry", "r")]
    [InlineData("brybbr", "r")]
    [InlineData("rbyryrrbyrbb", "y")]
    [InlineData("yrbbbbryyrybb", "b")]
    public void ColourTrioTest(string colours, string expected)
    {
        string actual = ColourTrio.IsColourTrio(colours);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] { 42, 7, 12, 9, 2, 5 }, 4)]
    [InlineData(new int[] { }, 0)]
    // in the pdf the expected result is 2, but 5 is bigger than everything on the right, so is -1 and so is -3 as its the last in the list.
    [InlineData(new int[] { -2, 5, -1, -3 }, 3)]
    [InlineData(new int[] { -10, -20, -30, -42 }, 4)]
    [InlineData(new int[] { 42, 42, 42, 42 }, 1)]
    [InlineData(new int[] { 0, 1, 2, 3, 4 }, 1)]
    [InlineData(new int[] { 5, 4, 3, 2, 1 }, 5)]
    public void CountDominatorsTest(int[] items, int expected)
    {
        int actual = CountDominators.CountDominatorItems(items);
        Assert.Equal(expected, actual);
    }
}
