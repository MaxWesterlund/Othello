using System.Linq;

public class Bot
{
    static Placement placement = new();
    public static Square ChooseSquare(State state)
    {
        List<Tuple<int, int>> possibleMoves = new();
        //List<Square> possibleMoves = new();
        for (int index = 0; index < 63; index++)
        {
            List<Square> affectedSquares = new();

            affectedSquares.AddRange(placement.Fill(Setup.board.squares[index], state, index, 1));
            affectedSquares.AddRange(placement.Fill(Setup.board.squares[index], state, index, -1));
            affectedSquares.AddRange(placement.Fill(Setup.board.squares[index], state, index, 8));
            affectedSquares.AddRange(placement.Fill(Setup.board.squares[index], state, index, -8));
            affectedSquares.AddRange(placement.Fill(Setup.board.squares[index], state, index, 7));
            affectedSquares.AddRange(placement.Fill(Setup.board.squares[index], state, index, -7));
            affectedSquares.AddRange(placement.Fill(Setup.board.squares[index], state, index, 9));
            affectedSquares.AddRange(placement.Fill(Setup.board.squares[index], state, index, -9));

            possibleMoves.Add(new Tuple<int, int>(index, affectedSquares.Count));
        }
        possibleMoves = possibleMoves.OrderByDescending(tuple => tuple.Item2).ToList();
        return Setup.board.squares[possibleMoves[0].Item1];
    }
}