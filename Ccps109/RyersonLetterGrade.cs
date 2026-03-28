namespace Ccps109;

public class RyersonLetterGrade
{
    public static void Main(string[] args)
    {
        int[] numbers = ParseInput(args);
        List<string> output = [];

        foreach (int num in numbers)
        {
            output.Add(GetGrade(num));
        }
        Console.WriteLine($"output {output}");
    }

    public static string GetGrade(int pct)
    {
        if (pct >= 90)
        {
            return "A+";
        }
        else if (pct <= 89 && pct >= 85)
        {
            return "A";
        }
        else if (pct <= 84 && pct >= 80)
        {
            return "A-";
        }
        else if (pct <= 79 && pct >= 77)
        {
            return "B+";
        }
        else if (pct <= 76 && pct >= 73)
        {
            return "B";
        }
        else if (pct <= 72 && pct >= 70)
        {
            return "B-";
        }
        else if (pct <= 69 && pct >= 67)
        {
            return "C+";
        }
        else if (pct <= 66 && pct >= 63)
        {
            return "C";
        }
        else if (pct <= 62 && pct >= 60)
        {
            return "C-";
        }
        else if (pct <= 59 && pct >= 57)
        {
            return "D+";
        }
        else if (pct <= 56 && pct >= 53)
        {
            return "D";
        }
        else if (pct <= 52 && pct >= 50)
        {
            return "D-";
        }
        return "F";
    }

    static int[] ParseInput(string[] args)
    {
        if (args.Length == 0)
        {
            throw new ArgumentException("No arguments were provided. At least one number is required.");
        }

        return [.. args.Select(s => int.TryParse(s, out int n) ? (int?)n : null).OfType<int>()];
    }
}
