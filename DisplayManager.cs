using System;

public class DisplayManager
{
    private Board board;

    public DisplayManager(Board board)
    {
        this.board = board;
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("=== BEJEWELED ===\n");

        // Display column numbers
        Console.Write("  ");
        for (int j = 0; j < board.Cols; j++)
        {
            Console.Write(j + " ");
        }
        Console.WriteLine();

        // Display board with row numbers
        for (int i = 0; i < board.Rows; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < board.Cols; j++)
            {
                Gem? gem = board.GetGem(i, j);
                if (gem == null)
                {
                    Console.Write(". ");
                }
                else
                {
                    Console.Write(gem.getColor() + " ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void DisplayScore(int score)
    {
        Console.WriteLine($"Score: {score}");
    }

    public void DisplayInstructions()
    {
        Console.WriteLine("Instructions:");
        Console.WriteLine("Enter row and column of first gem (e.g., '0 0')");
        Console.WriteLine("Enter row and column of second gem to swap (e.g., '0 1')");
        Console.WriteLine("Type 'exit' to quit\n");
    }
}
