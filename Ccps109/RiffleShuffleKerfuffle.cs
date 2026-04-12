namespace Ccps109;

public class RiffleShuffleKerfuffle
{
    public static T[] Riffle<T>(T[] items, bool outShuffle)
    {
        if (items.Length == 0)
        {
            return [];
        }

        T[] result = new T[items.Length];
        T[] firstHalf = items[..(items.Length / 2)];
        T[] secondHalf = items[(items.Length / 2)..];

        for (int i = 0; i < firstHalf.Length; i++)
        {
            int insertIndex = i * 2;

            result[insertIndex] = outShuffle ? firstHalf[i] : secondHalf[i];
            result[insertIndex + 1] = outShuffle ? secondHalf[i] : firstHalf[i];
        }
        return result;
    }
}
