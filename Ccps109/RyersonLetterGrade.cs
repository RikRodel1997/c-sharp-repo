namespace Ccps109;

public class RyersonLetterGrade
{
    public static string GetGrade(int pct)
    {
        return pct switch
        {
            >= 90 => "A+",
            <= 89 and >= 85 => "A",
            <= 84 and >= 80 => "A-",
            <= 79 and >= 77 => "B+",
            <= 76 and >= 73 => "B",
            <= 72 and >= 70 => "B-",
            <= 69 and >= 67 => "C+",
            <= 66 and >= 63 => "C",
            <= 62 and >= 60 => "C-",
            <= 59 and >= 57 => "D+",
            <= 56 and >= 53 => "D",
            <= 52 and >= 50 => "D-",
            _ => "F",
        };
    }
}
