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
                if (board.GetPiece(new Square(row + 1, col)) != null)
                {
                    if (board.GetPiece(new Square(row + 1, col)).Player != Player.Black)
                    {
                        movesList.Add(new Square(row + 1, col));
                    }
                }
                else
                {
                    movesList.Add(new Square(row + 1, col));
                }
            }
            else
            {
                if (board.GetPiece(new Square(row - 1, col)) != null)
                {
                    if (board.GetPiece(new Square(row - 1, col)).Player != Player.White)
                    {
                        movesList.Add(new Square(row - 1, col));
                    }
                }
                else
                {
                    movesList.Add(new Square(row - 1, col));
                }
            }
            
            return movesList;
        }
    }
}