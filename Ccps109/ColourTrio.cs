using System.Text;

namespace Ccps109;

public class ColourTrio
{
    public static string IsColourTrio(string colours)
    {
        if (colours.Length == 1)
            return colours;

        string result = colours;

        while (result.Length != 1)
        {
            StringBuilder colourSet = new();
            for (int i = 0; i < result.Length - 1; i++)
            {
                char firstColour = result[i];
                char secondColour = result[i + 1];
                char newColour = MixColours(firstColour, secondColour);
                colourSet.Append(newColour);
            }
            result = colourSet.ToString();
        }

        return result;
    }

    private static char MixColours(char colour1, char colour2)
    {
        return (colour1, colour2) switch
        {
            ('r', 'r') => 'r',
            ('y', 'y') => 'y',
            ('b', 'b') => 'b',
            ('r', 'y') => 'b',
            ('y', 'r') => 'b',
            ('y', 'b') => 'r',
            ('b', 'y') => 'r',
            ('b', 'r') => 'y',
            ('r', 'b') => 'y',
            _ => throw new InvalidDataException($"{colour1} or ${colour2} is invalid"),
        };
    }
}
