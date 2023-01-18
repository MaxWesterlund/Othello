using Raylib_cs;

public class Bot
{
    static Board board = new();
    static Placement placement = new();
    public static Square ChooseSquare(State state)
    {
        List<Tuple<int, int>> possibleMoves = new();
        List<Tuple<int, int>> keepMoves = new();
        for (int index = 0; index < 63; index++)
        {
            List<Square> affectedSquares = new();

            affectedSquares.AddRange(placement.Fill(Board.squares[index], state, index, 1));
            affectedSquares.AddRange(placement.Fill(Board.squares[index], state, index, -1));
            affectedSquares.AddRange(placement.Fill(Board.squares[index], state, index, 8));
            affectedSquares.AddRange(placement.Fill(Board.squares[index], state, index, -8));
            affectedSquares.AddRange(placement.Fill(Board.squares[index], state, index, 7));
            affectedSquares.AddRange(placement.Fill(Board.squares[index], state, index, -7));
            affectedSquares.AddRange(placement.Fill(Board.squares[index], state, index, 9));
            affectedSquares.AddRange(placement.Fill(Board.squares[index], state, index, -9));

            if (affectedSquares.Count > 0)
            {
                possibleMoves.Add(new Tuple<int, int>(index, affectedSquares.Count));
            }   
        }
        possibleMoves = possibleMoves.OrderByDescending(tuple => tuple.Item2).ToList();

        Console.WriteLine(possibleMoves.Count);

        for (int index = 0; index < possibleMoves.Count - 1; index++)
        {
            if (Board.squares[possibleMoves[index].Item1].xPos == 0 || Board.squares[possibleMoves[index].Item1].xPos == 7 ||
                Board.squares[possibleMoves[index].Item1].yPos == 0 || Board.squares[possibleMoves[index].Item1].yPos == 7)
            {
                keepMoves.Add(new Tuple<int, int>(possibleMoves[index].Item1, possibleMoves[index].Item2));
            }
        }
        if (keepMoves.Count > 0)
        {
            possibleMoves = keepMoves;
        }

        Console.WriteLine(possibleMoves.Count);
        if (possibleMoves.Count == 0)
        {
            return new Square(100, 100);
        }
        else
        {
            return Board.squares[possibleMoves[0].Item1];
        }
    }
}