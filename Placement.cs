using Raylib_cs;
using System;
using System.Numerics;

public class Placement
{
    public bool isBlacksTurn = true;
    float prevTime = 0;
    float botWaitTime = 0.3f;
    List<Square> affectedSquares = new();

    public void GetMouse()
    {
        if (!isBlacksTurn)
        {
            if ((float)Raylib.GetTime() - prevTime > botWaitTime)
            {
                TurnTiles(Bot.ChooseSquare(State.White), State.White);
            }
        }
        else if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            foreach (Square currentSquare in Setup.board.squares)
            {
                if (Raylib.GetMouseX() > currentSquare.xPos * Square.size && Raylib.GetMouseX() < currentSquare.xPos * Square.size + Square.size &&
                    Raylib.GetMouseY() > currentSquare.yPos * Square.size && Raylib.GetMouseY() < currentSquare.yPos * Square.size + Square.size)
                {                
                    if (isBlacksTurn)
                    {
                        TurnTiles(currentSquare, State.Black);
                    }
                    prevTime = (float)Raylib.GetTime();    
                }
            }
        }
    }

    void TurnTiles(Square originalSquare, State state)
    {
        affectedSquares.Clear();
        int originalIndex = Array.IndexOf(Setup.board.squares, originalSquare);
        Square currentSquare = Setup.board.squares[originalIndex];
        affectedSquares.AddRange(Fill(originalSquare, state, originalIndex, 1));
        affectedSquares.AddRange(Fill(originalSquare, state, originalIndex, -1));
        affectedSquares.AddRange(Fill(originalSquare, state, originalIndex, 8));
        affectedSquares.AddRange(Fill(originalSquare, state, originalIndex, -8));
        affectedSquares.AddRange(Fill(originalSquare, state, originalIndex, 7));
        affectedSquares.AddRange(Fill(originalSquare, state, originalIndex, -7));
        affectedSquares.AddRange(Fill(originalSquare, state, originalIndex, 9));
        affectedSquares.AddRange(Fill(originalSquare, state, originalIndex, -9));

        foreach (Square sqr in affectedSquares)
        {
            sqr.state = state;
        }
        if (affectedSquares.Count == 0)
        {
            return;
        }
        else
        {
            originalSquare.state = state;
        }
        isBlacksTurn = !isBlacksTurn;
    }

    public List<Square> Fill(Square startSquare, State state, int startIndex, int jump)
    {
        if (startSquare.state != State.Empty)
        {
            return new List<Square>();
        } 

        bool shouldTurn = false;
        List<Square> localAffectedSquares = new();
        int index = startIndex + jump;
        int prevIndex = index - jump;
        if (index >= 63 || index <= 0)
        {
            return new List<Square>();
        }

        Square currentSquare = Setup.board.squares[index];
        while (currentSquare.state != State.Empty && currentSquare != null)
        {
            if (index >= 63 || index <= 0)
            {
                return new List<Square>();
            }
            if (Math.Abs(Setup.board.squares[index].xPos - Setup.board.squares[prevIndex].xPos) > 1 ||
                Math.Abs(Setup.board.squares[index].yPos - Setup.board.squares[prevIndex].yPos) > 1)
            {
                return new List<Square>();
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
            prevIndex = index;
            index += jump;   
        }
        if (shouldTurn)
        {
            affectedSquares.AddRange(localAffectedSquares);
            if (localAffectedSquares.Count > 0)
            {
                localAffectedSquares.Add(startSquare);
            }
            return localAffectedSquares;
        }
        return new List<Square>();
    }
}