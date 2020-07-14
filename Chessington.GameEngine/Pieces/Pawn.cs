using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var col = board.FindPiece(this).Col;
            var row = board.FindPiece(this).Row;
            var movesList = new List<Square>();
            Square farSquare;
            Square square;
            var diagonalSquares = new List<Square>();
            
            if (Player == Player.Black)
            {
                farSquare = new Square(row + 2, col);
                square = new Square(row + 1, col);
                diagonalSquares.Add(new Square(row + 1, col - 1));
                diagonalSquares.Add(new Square(row + 1, col + 1));
            }
            else
            {
                farSquare = new Square(row - 2, col);
                square = new Square(row - 1, col);
                diagonalSquares.Add(new Square(row - 1, col - 1));
                diagonalSquares.Add(new Square(row - 1, col + 1));
            }

            if (square.IsWithinBoard() && board.GetPiece(square) == null)
            {
                movesList.Add(square);
                
                if (!hasMoved && board.GetPiece(farSquare) == null)
                {
                    movesList.Add(farSquare);
                }
            }
            
            foreach (var sq in diagonalSquares)
            {
                if (sq.IsWithinBoard() && board.GetPiece(sq) != null && board.GetPiece(sq).Player != this.Player)
                {
                    movesList.Add(sq);
                }
            }

            return movesList;
        }
        
    }
}