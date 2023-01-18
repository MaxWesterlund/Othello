using Raylib_cs;

class Program
{
    static Board board = new();
    static Placement placement = new();
    static void Main()
    {
        Raylib.InitWindow(800, 800, "Othello Bot");
        board.BoardSetup();
        while (!Raylib.WindowShouldClose())
        {
            board.Draw();
            placement.GetMouse();
        }
        Raylib.CloseWindow();
    }
}