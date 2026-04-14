namespace Ccps109;

public class BeatThePrevious
{
    public static long[] ExtractIncreasing(string digits)
    {
        List<long> result = [];
        long current = 0;
        long previous = 0;

        foreach (char digit in digits)
        {
            long numericDigit = (long)char.GetNumericValue(digit);
            if (result.Count == 0)
            {
                result.Add(numericDigit);
                previous = numericDigit;
                continue;
            }

            if (numericDigit > previous)
            {
                current = AddDigit(current, numericDigit);
                result.Add(current);
                previous = current;
                current = 0;
                continue;
            }

            current = AddDigit(current, numericDigit);

            if (current > previous)
            {
                result.Add(current);
                previous = current;
                current = 0;
            }
        }

        return [.. result];
    }

    private static long AddDigit(long current, long digit)
    {
        return 10 * current + digit;
    }
}
