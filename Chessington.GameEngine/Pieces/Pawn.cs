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
            
            if (Player == Player.Black)
            {
                farSquare = new Square(row + 2, col);
                if (!HasMoved(board) && farSquare.NotOwnedBy(Player.Black, board))
                {
                    movesList.Add(farSquare);
                }
                var square = new Square(row + 1, col);
                if (square.NotOwnedBy(Player.Black, board))
                {
                    movesList.Add(square);
                }
            }
            else
            {
                farSquare = new Square(row - 2, col);
                if (!HasMoved(board) && farSquare.NotOwnedBy(Player.White, board))
                {
                    movesList.Add(farSquare);
                }
                var square = new Square(row - 1, col);
                if (square.NotOwnedBy(Player.White, board))
                {
                    movesList.Add(square);
                }
            }
            
            return movesList;
        }

        private bool HasMoved(Board board)
        {
            var col = board.FindPiece(this).Col;
            var row = board.FindPiece(this).Row;
            return !(Player == Player.Black && row == 1 && Enumerable.Range(0, 8).Contains(col) ||
                     Player == Player.White && row == 7 && Enumerable.Range(0, 8).Contains(col));
        }
    }
}