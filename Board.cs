using Raylib_cs;
using System.Numerics;

public class Board
{
    public static Square[] squares = new Square[] {
        new Square(0, 0), new Square(1, 0), new Square(2, 0), new Square(3, 0),
        new Square(4, 0), new Square(5, 0), new Square(6, 0), new Square(7, 0),
        new Square(0, 1), new Square(1, 1), new Square(2, 1), new Square(3, 1), 
        new Square(4, 1), new Square(5, 1), new Square(6, 1), new Square(7, 1),
        new Square(0, 2), new Square(1, 2), new Square(2, 2), new Square(3, 2), 
        new Square(4, 2), new Square(5, 2), new Square(6, 2), new Square(7, 2),
        new Square(0, 3), new Square(1, 3), new Square(2, 3), new Square(3, 3), 
        new Square(4, 3), new Square(5, 3), new Square(6, 3), new Square(7, 3),
        new Square(0, 4), new Square(1, 4), new Square(2, 4), new Square(3, 4), 
        new Square(4, 4), new Square(5, 4), new Square(6, 4), new Square(7, 4),
        new Square(0, 5), new Square(1, 5), new Square(2, 5), new Square(3, 5), 
        new Square(4, 5), new Square(5, 5), new Square(6, 5), new Square(7, 5),
        new Square(0, 6), new Square(1, 6), new Square(2, 6), new Square(3, 6), 
        new Square(4, 6), new Square(5, 6), new Square(6, 6), new Square(7, 6),
        new Square(0, 7), new Square(1, 7), new Square(2, 7), new Square(3, 7), 
        new Square(4, 7), new Square(5, 7), new Square(6, 7), new Square(7, 7)
    };

    public void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(new Color(36, 102, 36, 255));
        foreach (Square currentSquare in squares)
        {
            currentSquare.DrawSquares();
        }
        DrawStatus();
        Raylib.EndDrawing();
    }

    void DrawStatus()
    {
        Raylib.DrawCircle(720, 64, 32, Color.BLACK);       
        int blackMargin = Raylib.MeasureText(PointsCounter()[0].ToString(), 40);
        Raylib.DrawText(PointsCounter()[0].ToString(), (int)(720f - blackMargin/2f), 104, 40, Color.BLACK);
        Raylib.DrawCircle(720, 194, 32, Color.WHITE);
        int whiteMargin = Raylib.MeasureText(PointsCounter()[1].ToString(), 40);
        Raylib.DrawText(PointsCounter()[1].ToString(), (int)(720f - whiteMargin/2f), 234, 40, Color.WHITE);
    }

    public void BoardSetup()
    {
        squares[27].state = State.White;
        squares[28].state = State.Black;
        squares[35].state = State.Black;
        squares[36].state = State.White;
    }

    int[] PointsCounter()
    {
        int blackPoints = 0;
        int whitePoints = 0;
        foreach (Square currentSquare in squares)
        {
            switch (currentSquare.state)
            {
                case State.Black:
                    blackPoints += 1;
                    break;
                
                case State.White:
                    whitePoints += 1;
                    break;
            }
        }
        return new int[] {blackPoints, whitePoints};
    }
}

public enum State
{
    Black,
    White,
    Empty
}

public class Square
{
    public int xPos = 0;
    public int yPos = 0;
    public static int size = 80;
    static int margin = 8;
    Color color = Color.PINK;

    static Color lGreen = new Color(51, 138, 51, 255);
    static Color dGreen = new Color(36, 102, 36, 255);


    public State state = State.Empty;

    public Square(int x, int y)
    {
        xPos = x;
        yPos = y;
    }

    public void DrawSquares()
    {
        Raylib.DrawRectangle(xPos * size + margin, yPos * size + margin, size - margin, size - margin, new Color(51, 138, 51, 255));
        switch (state)
        {
            case State.Black:
                Raylib.DrawCircle((xPos * 10 + 5) * (size / 10) + margin / 2, (yPos * 10 + 5) * (size / 10) + margin / 2, size / 2 - 8, Color.BLACK);
                break;

            case State.White:
                Raylib.DrawCircle((xPos * 10 + 5) * (size / 10) + margin / 2, (yPos * 10 + 5) * (size / 10) + margin / 2, size / 2 - 8, Color.WHITE);
                break;
        }
    }
}