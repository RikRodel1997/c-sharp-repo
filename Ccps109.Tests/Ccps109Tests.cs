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
    public void EvenTheOddsTest(long n, bool expected)
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
    public void CyclopsNumbersTest(int n, bool expected)
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
        // because we can"t pass tuples into InlineDate
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

    [Theory]
    [InlineData("600005", new long[] { 6 })]
    [InlineData("045349", new long[] { 0, 4, 5, 34 })]
    [InlineData("77777777777777777777777", new long[] { 7, 77, 777, 7777, 77777, 777777 })]
    [InlineData("122333444455555666666", new long[] { 1, 2, 23, 33, 44, 445, 555, 566, 666 })]
    [InlineData(
        "2718281828459045235360287471352662497757247093699959574966967627724076630353547594571382178525166427427466391932003059921817413596629043572900334295260",
        new long[]
        {
            2,
            7,
            18,
            28,
            182,
            845,
            904,
            5235,
            36028,
            74713,
            526624,
            977572,
            4709369,
            9959574,
            96696762,
            772407663,
            3535475945,
            7138217852,
            51664274274,
            66391932003,
            599218174135,
            966290435729,
        }
    )]
    public void BeatThePreviousTest(string digits, long[] expected)
    {
        long[] actual = BeatThePrevious.ExtractIncreasing(digits);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(
        "klore",
        new string[]
        {
            "booklore",
            "booklores",
            "folklore",
            "folklores",
            "kaliborite",
            "kenlore",
            "kiloampere",
            "kilocalorie",
            "kilocurie",
            "kilogramme",
            "kilogrammetre",
            "kilolitre",
            "kilometrage",
            "kilometre",
            "kilooersted",
            "kiloparsec",
            "kilostere",
            "kiloware",
        }
    )]
    [InlineData(
        "brohiic",
        new string[] { "bronchiectatic", "bronchiogenic", "bronchitic", "ombrophilic", "timbrophilic" }
    )]
    [InlineData(
        "azaz",
        new string[] { "azazel", "azotetrazole", "azoxazole", "diazoaminobenzene", "hazardize", "razzmatazz" }
    )]
    public void SubsequentWordsTest(string letters, string[] expected)
    {
        string[] words = [];
        try
        {
            using StreamReader reader = new("words_sorted.txt");
            words = reader.ReadToEnd().Split("\n");
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

        string[] actual = SubsequentWords.WordsWithLetters(words, letters);
        Assert.Equal(expected, actual);
    }
}
