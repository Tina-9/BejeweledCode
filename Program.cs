class Program
{
    static void Main(string[] args)
    {
        Board board = new Board(5, 5);

        board.BoardFill();
        board.Display();
    }
}