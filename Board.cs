using Raylib_cs;

public class Board
{
    static Color lGreen = new Color(51, 138, 51, 255);
    static Color dGreen = new Color(36, 102, 36, 255);

    static Square[] squares = new Square[] {
        new Square(0, 0, lGreen), new Square(1, 0, dGreen), new Square(2, 0, lGreen), new Square(3, 0, dGreen), 
        new Square(4, 0, lGreen), new Square(5, 0, dGreen), new Square(6, 0, lGreen), new Square(7, 0, dGreen),
        new Square(0, 1, dGreen), new Square(1, 1, lGreen), new Square(2, 1, dGreen), new Square(3, 1, lGreen), 
        new Square(4, 1, dGreen), new Square(5, 1, lGreen), new Square(6, 1, dGreen), new Square(7, 1, lGreen),
        new Square(0, 2, lGreen), new Square(1, 2, dGreen), new Square(2, 2, lGreen), new Square(3, 2, dGreen), 
        new Square(4, 2, lGreen), new Square(5, 2, dGreen), new Square(6, 2, lGreen), new Square(7, 2, dGreen),
        new Square(0, 3, dGreen), new Square(1, 3, lGreen), new Square(2, 3, dGreen), new Square(3, 3, lGreen), 
        new Square(4, 3, dGreen), new Square(5, 3, lGreen), new Square(6, 3, dGreen), new Square(7, 3, lGreen),
        new Square(0, 4, lGreen), new Square(1, 4, dGreen), new Square(2, 4, lGreen), new Square(3, 4, dGreen), 
        new Square(4, 4, lGreen), new Square(5, 4, dGreen), new Square(6, 4, lGreen), new Square(7, 4, dGreen),
        new Square(0, 5, dGreen), new Square(1, 5, lGreen), new Square(2, 5, dGreen), new Square(3, 5, lGreen), 
        new Square(4, 5, dGreen), new Square(5, 5, lGreen), new Square(6, 5, dGreen), new Square(7, 5, lGreen),
        new Square(0, 6, lGreen), new Square(1, 6, dGreen), new Square(2, 6, lGreen), new Square(3, 6, dGreen), 
        new Square(4, 6, lGreen), new Square(5, 6, dGreen), new Square(6, 6, lGreen), new Square(7, 6, dGreen),
        new Square(0, 7, dGreen), new Square(1, 7, lGreen), new Square(2, 7, dGreen), new Square(3, 7, lGreen), 
        new Square(4, 7, dGreen), new Square(5, 7, lGreen), new Square(6, 7, dGreen), new Square(7, 7, lGreen),
    };

    public static void MakeBoard()
    {
        Raylib.InitWindow(640, 640, "Othello Bot");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);
            foreach (Square currentSquare in squares)
            {
                currentSquare.Draw();
            }
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}

public class Square
{
    int xPos = 0;
    int yPos = 0;
    Color color = Color.PINK;

    string state = "white";

    public Square(int x, int y, Color col)
    {
        xPos = x;
        yPos = y;
        color = col;
    }

    public void Draw()
    {
        Raylib.DrawRectangle(xPos * 80, yPos * 80, 80, 80, color: color);
        if (state == "black")
        {
            Raylib.DrawCircle((xPos * 10 + 5) * 8, (yPos * 10 + 5) * 8, 39, Color.BLACK);
        }
        else if (state == "white")
        {
            Raylib.DrawCircle((xPos * 10 + 5) * 8, (yPos * 10 + 5) * 8, 39, Color.WHITE);
        }
    }
}