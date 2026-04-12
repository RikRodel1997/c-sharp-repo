namespace Ccps109;

public class AscendingList
{
    public static bool IsAscending(int[] numbers)
    {
        bool isAscending = true;

        foreach (var (prev, curr) in numbers.Zip(numbers.Skip(1)))
        {
            if (prev < curr)
                continue;
            else
            {
                isAscending = false;
                break;
            }
        }

        return isAscending;
    }
}
