namespace Ccps109;

public class DominoCycle
{
    public static bool IsDominoCycle((int, int)[] tiles)
    {
        int tilesCount = tiles.Length;
        if (tilesCount == 0)
        {
            return true;
        }

        if (tilesCount == 1)
        {
            return tiles[0].Item1 == tiles[0].Item2;
        }

        var (firstTileFirstPip, _) = tiles[0];
        var (_, previousTileSecondPip) = tiles[0];

        for (int i = 1; i < tilesCount; i++)
        {
            var (pip1, pip2) = tiles[i];
            if (pip1 == previousTileSecondPip)
            {
                if (i == tilesCount - 1)
                {
                    if (pip2 == firstTileFirstPip)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                previousTileSecondPip = pip2;
                continue;
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}
