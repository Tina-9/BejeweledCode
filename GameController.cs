using System;
using System.Collections.Generic;

public class GameController
{
    private Board board;
    private DisplayManager displayManager;
    private MoveValidator moveValidator;
    private MatchFinder matchFinder;
    private int score;
    private bool isRunning;

    public GameController(int rows, int cols)
    {
        board = new Board(rows, cols);
        displayManager = new DisplayManager(board);
        moveValidator = new MoveValidator(board);
        matchFinder = new MatchFinder(board);
        score = 0;
        isRunning = true;
    }

    public void Start()
    {
        board.BoardFill();
        CheckForMatches();  // Check for initial matches
        displayManager.DisplayInstructions();
        GameLoop();
    }

    private void GameLoop()
    {
        while (isRunning)
        {
            displayManager.Display();
            displayManager.DisplayScore(score);
            ProcessInput();
        }
    }

    private void ProcessInput()
    {
        try
        {
            Console.Write("Enter first gem position (row col) or 'quit': ");
            string? input = Console.ReadLine();

            if (input == null || input.ToLower() == "quit" || input.ToLower() == "exit")
            {
                isRunning = false;
                Console.WriteLine("Thanks for playing!");
                return;
            }

            string[] parts = input.Split(' ');
            if (parts.Length != 2 || !int.TryParse(parts[0], out int row1) || !int.TryParse(parts[1], out int col1))
            {
                displayManager.DisplayMessage("Invalid input. Please enter row and column as numbers.\n");
                return;
            }

            Console.Write("Enter second gem position (row col): ");
            input = Console.ReadLine();

            if (input == null)
            {
                displayManager.DisplayMessage("Invalid input.\n");
                return;
            }

            parts = input.Split(' ');
            if (parts.Length != 2 || !int.TryParse(parts[0], out int row2) || !int.TryParse(parts[1], out int col2))
            {
                displayManager.DisplayMessage("Invalid input. Please enter row and column as numbers.\n");
                return;
            }

            if (moveValidator.CanSwap(row1, col1, row2, col2))
            {
                SwapGems(row1, col1, row2, col2);
                CheckForMatches();
                displayManager.DisplayMessage("Swap successful!\n");
            }
            else
            {
                displayManager.DisplayMessage("Invalid move! Gems must be adjacent.\n");
            }
        }
        catch (Exception ex)
        {
            displayManager.DisplayMessage($"Error: {ex.Message}\n");
        }
    }

    private void SwapGems(int row1, int col1, int row2, int col2)
    {
        Gem? temp = board.GetGem(row1, col1);
        board.setGem(row1, col1, board.GetGem(row2, col2));
        board.setGem(row2, col2, temp);

        // Update gem positions
        board.GetGem(row1, col1)?.SetPosition(row1, col1);
        board.GetGem(row2, col2)?.SetPosition(row2, col2);
    }

    private void CheckForMatches()
    {
        while (matchFinder.HasMatches())
        {
            List<(int, int)> matches = matchFinder.FindMatches();
            int pointsEarned = matches.Count * 10;
            score += pointsEarned;

            displayManager.DisplayMessage($"Match found! +{pointsEarned} points!");

            board.RemoveGems(matches);
            board.RefillBoard();
        }
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public void Stop()
    {
        isRunning = false;
    }
}
