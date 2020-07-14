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
            
            if (Player == Player.Black)
            {
                if (row == 1 && Enumerable.Range(0, 8).Contains(col) && new Square(row+2, col).NotOwnedBy(Player.Black, board))
                {
                    movesList.Add(new Square(row+2, col));
                }
                var square = new Square(row+1, col);
                if (square.NotOwnedBy(Player.Black, board))
                {
                    movesList.Add(square);
                }
            }
            else
            {
                if (row == 7 && Enumerable.Range(0, 8).Contains(col) && new Square(row-2, col).NotOwnedBy(Player.White, board))
                {
                    movesList.Add(new Square(row-2, col));
                }
                var square = new Square(row-1, col);
                if (square.NotOwnedBy(Player.White, board))
                {
                    movesList.Add(square);
                }
            }
            
            return movesList;
        }
    }
}