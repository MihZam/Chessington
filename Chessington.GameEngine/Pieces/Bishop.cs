using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var col = board.FindPiece(this).Col;
            var row = board.FindPiece(this).Row;
            var movesList = new List<Square>();

            for (var i = -Math.Min(row, col); i < Math.Max(8 - row, 8 - col); i++)
            {
                if (i != 0)
                {
                    movesList.Add(new Square(row + i, col + i));
                }
            }
            
            for (var i = -Math.Min(row,7 - col); i < Math.Max(8 - row, col); i++)
            {
                if (i != 0)
                {
                    movesList.Add(new Square(row + i, col - i));
                }
            }

            return movesList;
        }
    }
}