namespace CcWc.Tests;

public class CcWcTests
{
    [Theory]
    [InlineData("test.txt", 342190)]
    [InlineData("lorum-ipsum.txt", 445)]
    [InlineData("csv-style.txt", 16802)]
    public void ByteCountTest(string fileName, int expected)
    {
        using StringWriter sw = new();
        Console.SetOut(sw);

        try
        {
            string[] args = ["-c", fileName];
            Program.Main(args);

            string result = sw.ToString();
            string byteCount = result.Split(" ")[0];

            Assert.Equal(expected, int.Parse(byteCount));
        }
        finally
        {
            StreamWriter standardOut = new(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
        }
    }

    [Theory]
    [InlineData("test.txt", 7145)]
    [InlineData("lorum-ipsum.txt", 0)]
    [InlineData("csv-style.txt", 1003)]
    public void LineCountTest(string fileName, int expected)
    {
        using StringWriter sw = new();
        Console.SetOut(sw);

        try
        {
            string[] args = ["-l", fileName];
            Program.Main(args);

            string result = sw.ToString();
            string lineCount = result.Split(" ")[0];

            Assert.Equal(expected, int.Parse(lineCount));
        }
        finally
        {
            StreamWriter standardOut = new(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
        }
    }

    [Theory]
    [InlineData("test.txt", 58164)]
    [InlineData("lorum-ipsum.txt", 69)]
    [InlineData("csv-style.txt", 1017)]
    public void WordCountTest(string fileName, int expected)
    {
        using StringWriter sw = new();
        Console.SetOut(sw);

        try
        {
            string[] args = ["-w", fileName];
            Program.Main(args);

            string result = sw.ToString();
            string wordCount = result.Split(" ")[0];

            Assert.Equal(expected, int.Parse(wordCount));
        }
        finally
        {
            StreamWriter standardOut = new(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
        }
    }

    [Theory]
    [InlineData("test.txt", 339292)]
    [InlineData("lorum-ipsum.txt", 445)]
    [InlineData("csv-style.txt", 16802)]
    public void CharCountTest(string fileName, int expected)
    {
        using StringWriter sw = new();
        Console.SetOut(sw);

        try
        {
            string[] args = ["-m", fileName];
            Program.Main(args);

            string result = sw.ToString();
            string charCount = result.Split(" ")[0];

            Assert.Equal(expected, int.Parse(charCount));
        }
        finally
        {
            StreamWriter standardOut = new(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
        }
    }

    [Theory]
    [InlineData("test.txt", new int[] { 342190, 7145, 58164 })]
    [InlineData("lorum-ipsum.txt", new int[] { 445, 0, 69 })]
    [InlineData("csv-style.txt", new int[] { 16802, 1003, 1017 })]
    public void NoFlagTest(string fileName, int[] expected)
    {
        using StringWriter sw = new();
        Console.SetOut(sw);

        try
        {
            string[] args = [fileName];
            Program.Main(args);

            string result = sw.ToString();
            int[] counts =
            [
                .. result
                    .Split([' ', '\t', '\r', '\n'], StringSplitOptions.RemoveEmptyEntries)
                    .Where(s => int.TryParse(s, out _))
                    .Select(int.Parse),
            ];
            Assert.Equal(expected, counts);
        }
        finally
        {
            StreamWriter standardOut = new(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
        }
    }

    [Fact]
    public void PipedInputTest()
    {
        string simulatedInput = "Hello World";

        using StringReader sr = new(simulatedInput);
        using StringWriter sw = new();

        Console.SetIn(sr);
        Console.SetOut(sw);

        try
        {
            string[] args = ["-c"];
            Program.Main(args);

            string result = sw.ToString();
            string count = result.Split(" ")[0];

            Assert.Equal(11, int.Parse(count));
        }
        finally
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            StreamWriter standardOut = new(Console.OpenStandardOutput()) { AutoFlush = true };
            Console.SetOut(standardOut);
        }
    }
}
