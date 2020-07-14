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
                var square = new Square(i, col);
                if (i != row)
                {
                    movesList.Add(square);
                }
            }

            for (var j = 0; j < 8; j++)
            {
                var square = new Square(row, j);
                if (j != col)
                {
                    movesList.Add(square);
                }
            }

            return movesList;
        }
    }
}