using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var col = board.FindPiece(this).Col;
            var row = board.FindPiece(this).Row;
            var movesList = new List<Square>();

            for (var i = 0; i < 8; i++)
            {
                if (i != row)
                {
                    movesList.Add(new Square(i, col));
                }
            }

            for (var j = 0; j < 8; j++)
            {
                if (j != col)
                {
                    movesList.Add(new Square(row, j));
                }
            }

            return movesList;
        }
    }
}