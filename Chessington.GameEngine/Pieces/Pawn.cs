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
            
            if (Player == Player.Black)
            {
                farSquare = new Square(row + 2, col);
                square = new Square(row + 1, col);
            }
            else
            {
                farSquare = new Square(row - 2, col);
                square = new Square(row - 1, col);
            }
            
            if (!hasMoved && farSquare.NotOwnedBy(Player, board))
            {
                movesList.Add(farSquare);
            }
            if (square.NotOwnedBy(Player, board))
            {
                movesList.Add(square);
            }
            
            return movesList;
        }
        
    }
}