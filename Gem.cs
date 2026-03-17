using System;

public class Gem
{
    private string color;
    private int row;
    private int col;

    public Gem(string color, int row, int col)
    {
        this.color = color;
        this.row = row;
        this.col = col;
    }

    public Gem getGem()
    {
        return this;
    }

    public void display()
    {
        Console.Write(color + " ");
    }

    public int getRow()
    {
        return row;
    }

    public int getCol()
    {
        return col;
    }

    public string getColor()
    {
        return color;
    }
}