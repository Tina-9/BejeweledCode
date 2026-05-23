using System;
using System.Collections.Generic;

public class Board
{
    private Gem?[,] grid;
    public int Rows;
    public int Cols;

    public Board(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        grid = new Gem?[rows, cols];
    }

    public Gem? GetGem(int row, int col)
    {
        return grid[row, col];
    }

    public void setGem(int row, int col, Gem? gem)
    {
        grid[row, col] = gem;
    }

    public void BoardFill()
    {
        string[] colors = { "R", "G", "B", "Y" };
        Random rand = new Random();

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                string color = colors[rand.Next(colors.Length)];
                grid[i, j] = new Gem(color, i, j);
            }
        }
    }

    public void Display()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                if (grid[i, j] != null)
                {
                    grid[i, j]?.display();
                }
            }
            Console.WriteLine();
        }
    }

    public void IsEmpty()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                if (grid[i, j] == null)
                {
                    Console.WriteLine($"Empty at {i},{j}");
                }
            }
        }
    }

    public void RemoveGems(List<(int row, int col)> gemsToRemove)
    {
        foreach ((int row, int col) in gemsToRemove)
        {
            grid[row, col] = null;
        }
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        for (int j = 0; j < Cols; j++)
        {
            for (int i = Rows - 1; i >= 0; i--)
            {
                if (grid[i, j] == null)
                {
                    // Find the next non-null gem above
                    int k = i - 1;
                    while (k >= 0 && grid[k, j] == null)
                    {
                        k--;
                    }

                    if (k >= 0)
                    {
                        grid[i, j] = grid[k, j];
                        grid[k, j] = null;
                        grid[i, j]!.SetPosition(i, j);
                    }
                }
            }
        }
    }

    public void RefillBoard()
    {
        string[] colors = { "R", "G", "B", "Y" };
        Random rand = new Random();

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                if (grid[i, j] == null)
                {
                    string color = colors[rand.Next(colors.Length)];
                    grid[i, j] = new Gem(color, i, j);
                }
            }
        }
    }
}