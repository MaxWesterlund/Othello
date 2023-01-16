using Raylib_cs;
using System;
using System.Numerics;

public class Placement
{
    bool isBlacksTurn = true;
    List<Square> affectedSquares = new();

    public void GetMouse()
    {
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            foreach (Square currentSquare in Setup.board.squares)
            {
                if (Raylib.GetMouseX() > currentSquare.xPos * Square.size && Raylib.GetMouseX() < currentSquare.xPos * Square.size + Square.size &&
                    Raylib.GetMouseY() > currentSquare.yPos * Square.size && Raylib.GetMouseY() < currentSquare.yPos * Square.size + Square.size)
                {
                    if (currentSquare.state != State.Empty)
                    {
                        return;
                    }                  
                    if (isBlacksTurn)
                    {
                        TurnTiles(currentSquare, State.Black);
                    }
                    else 
                    {
                        TurnTiles(currentSquare, State.White);
                    }
                }
            }
        }
    }

    void TurnTiles(Square originalSquare, State state)
    {
        int originalIndex = Array.IndexOf(Setup.board.squares, originalSquare);
        Square currentSquare = Setup.board.squares[originalIndex];
        Fill(currentSquare, state, originalIndex, 1);
        Fill(currentSquare, state, originalIndex, -1);
        Fill(currentSquare, state, originalIndex, 8);
        Fill(currentSquare, state, originalIndex, -8);
        Fill(currentSquare, state, originalIndex, 7);
        Fill(currentSquare, state, originalIndex, -7);
        Fill(currentSquare, state, originalIndex, 9);
        Fill(currentSquare, state, originalIndex, -9);
        Console.WriteLine(affectedSquares.Count);
        foreach (Square sqr in affectedSquares)
        {
            sqr.state = state;
        }
        if (affectedSquares.Count == 0)
        {
            return;
        }
        affectedSquares.Clear();
        isBlacksTurn = !isBlacksTurn;
    }

    void Fill(Square startSquare, State state, int startIndex, int jump)
    {
        bool shouldTurn = false;
        List<Square> localAffectedSquares = new();
        int index = startIndex + jump;
        if (index >= 63 || index <= 0)
        {
            return;
        }

        Square currentSquare = Setup.board.squares[index];
        while (currentSquare.state != State.Empty && currentSquare != null)
        {
            if (index >= 63 || index <= 0)
            {
                return;
            }
            currentSquare = Setup.board.squares[index];
            if (currentSquare.state == state)
            {
                shouldTurn = true;
                break;
            }
            else if (currentSquare.state != State.Empty)
            {
                localAffectedSquares.Add(currentSquare);
            }
            index += jump;
        }
        if (shouldTurn)
        {
            affectedSquares.AddRange(localAffectedSquares);
            if (localAffectedSquares.Count > 0)
            {
                startSquare.state = state;
            }
        }
    }
}