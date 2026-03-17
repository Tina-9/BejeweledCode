using System;

public class Board
{
    private Gem[,] grid;
    public int Rows;
    public int Cols;

    public Board(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        grid = new Gem[rows, cols];
    }

    public Gem GetGem(int row, int col)
    {
        return grid[row, col];
    }

    public void setGem(int row, int col, Gem gem)
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
                grid[i, j].display();
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
}