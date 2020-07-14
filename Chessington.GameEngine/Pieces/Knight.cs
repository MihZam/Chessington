using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var col = board.FindPiece(this).Col;
            var row = board.FindPiece(this).Row;
            var movesList = new List<Square>();

            movesList.Add(new Square(row-2, col-1));
            movesList.Add(new Square(row-2, col+1));
            
            movesList.Add(new Square(row+2, col-1));
            movesList.Add(new Square(row+2, col+1));
            
            movesList.Add(new Square(row-1, col-2));
            movesList.Add(new Square(row+1, col-2));
            
            movesList.Add(new Square(row-1, col+2));
            movesList.Add(new Square(row+1, col+2));
            
            return movesList;
        }
    }
}