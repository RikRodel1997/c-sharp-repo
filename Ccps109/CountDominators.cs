namespace Ccps109;

public class CountDominators
{
    public static int CountDominatorItems(int[] items)
    {
        if (items.Length == 0)
            return 0;

        int count = 1;
        int maxSeen = items[^1];

        for (int i = items.Length; i != 0; i--)
        {
            int current = items[i - 1];
            if (current > maxSeen)
            {
                maxSeen = current;
                count++;
            }
        }
        return count;
    }
}
