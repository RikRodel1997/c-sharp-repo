namespace Ccps109;

public class CyclopsNumbers
{
    public static bool IsCyclops(int n)
    {
        if (n == 0)
            return true;

        List<int> digits = [];
        while (n > 0)
        {
            int digit = n % 10;
            digits.Add(digit);
            n /= 10;
        }

        int length = digits.Count;
        if (length % 2 == 0)
            return false;

        int middle = (length - 1) / 2;
        if (digits[middle] != 0)
            return false;

        digits.RemoveAt(middle);

        foreach (int digit in digits)
        {
            if (digit == 0)
                return false;
        }

        return true;
    }
}
