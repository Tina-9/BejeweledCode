using System;
using System.Collections.Generic;

public class MatchFinder
{
    private Board board;

    public MatchFinder(Board board)
    {
        this.board = board;
    }

    public List<(int row, int col)> FindMatches()
    {
        List<(int, int)> matchedGems = new List<(int, int)>();

        // Check horizontal matches
        for (int i = 0; i < board.Rows; i++)
        {
            for (int j = 0; j < board.Cols; j++)
            {
                Gem? gem = board.GetGem(i, j);
                if (gem != null)
                {
                    // Check horizontal
                    int horizontalCount = 1;
                    int k = j + 1;
                    while (k < board.Cols)
                    {
                        Gem? nextGem = board.GetGem(i, k);
                        if (nextGem != null && nextGem.getColor() == gem.getColor())
                        {
                            horizontalCount++;
                            k++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (horizontalCount >= 3)
                    {
                        for (int m = j; m < j + horizontalCount; m++)
                        {
                            if (!matchedGems.Contains((i, m)))
                            {
                                matchedGems.Add((i, m));
                            }
                        }
                    }
                }
            }
        }

        // Check vertical matches
        for (int j = 0; j < board.Cols; j++)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Gem? gem = board.GetGem(i, j);
                if (gem != null)
                {
                    // Check vertical
                    int verticalCount = 1;
                    int k = i + 1;
                    while (k < board.Rows)
                    {
                        Gem? nextGem = board.GetGem(k, j);
                        if (nextGem != null && nextGem.getColor() == gem.getColor())
                        {
                            verticalCount++;
                            k++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (verticalCount >= 3)
                    {
                        for (int m = i; m < i + verticalCount; m++)
                        {
                            if (!matchedGems.Contains((m, j)))
                            {
                                matchedGems.Add((m, j));
                            }
                        }
                    }
                }
            }
        }

        return matchedGems;
    }

    public bool HasMatches()
    {
        return FindMatches().Count > 0;
    }
}
