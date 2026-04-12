namespace Ccps109;

public class EvenTheOdds
{
    public static bool OnlyOddDigits(long n)
    {
        if (n == 0)
            return false;

        bool onlyOdd = true;
        string str = n.ToString();
        foreach (char c in str)
        {
            long number = Convert.ToInt64(new string(c, 1));
            if (number % 2 == 0)
                onlyOdd = false;
        }
        return onlyOdd;
    }
}
