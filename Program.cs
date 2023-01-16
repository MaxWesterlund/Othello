using Raylib_cs;

class Program
{
    static Placement placement = new();
    static Setup setup = new();
    static void Main()
    {
        Raylib.InitWindow(640, 640, "Othello Bot");
        Setup.BoardSetup();
        while (!Raylib.WindowShouldClose())
        {
            setup.MakeBoard();
            placement.GetMouse();
        }
        Raylib.CloseWindow();
    }
}