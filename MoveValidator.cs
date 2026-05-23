using System;

public class MoveValidator
{
    private Board board;

    public MoveValidator(Board board)
    {
        this.board = board;
    }

    public bool IsValidPosition(int row, int col)
    {
        return row >= 0 && row < board.Rows && col >= 0 && col < board.Cols;
    }

    public bool CanSwap(int row1, int col1, int row2, int col2)
    {
        // Check if both positions are valid
        if (!IsValidPosition(row1, col1) || !IsValidPosition(row2, col2))
        {
            return false;
        }

        // Check if gems exist at both positions
        if (board.GetGem(row1, col1) == null || board.GetGem(row2, col2) == null)
        {
            return false;
        }

        // Check if positions are adjacent (up, down, left, right)
        int rowDiff = Math.Abs(row1 - row2);
        int colDiff = Math.Abs(col1 - col2);

        return (rowDiff == 1 && colDiff == 0) || (rowDiff == 0 && colDiff == 1);
    }

    public bool IsAdjacent(int row1, int col1, int row2, int col2)
    {
        int rowDiff = Math.Abs(row1 - row2);
        int colDiff = Math.Abs(col1 - col2);

        return (rowDiff == 1 && colDiff == 0) || (rowDiff == 0 && colDiff == 1);
    }
}
