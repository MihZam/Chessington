using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }
        
        protected bool hasMoved = false;

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
            hasMoved = true;
        }

        protected void addLateralMoves(List<Square> moves, int row, int col)
        {
            for (var i = 0; i < 8; i++)
            {
                var square = new Square(i, col);
                if (i != row)
                {
                    moves.Add(square);
                }
            }

            for (var j = 0; j < 8; j++)
            {
                var square = new Square(row, j);
                if (j != col)
                {
                    moves.Add(square);
                }
            }
        }
        
        protected void AddDiagonalMoves(List<Square> moves, int row, int col)
        {
            for (var i = -Math.Min(row, col); i < Math.Max(8 - row, 8 - col); i++)
            {
                var square = new Square(row + i, col + i);
                if (i != 0)
                {
                    moves.Add(square);
                }
            }
            
            for (var i = -Math.Min(row,7 - col); i < Math.Max(8 - row, col); i++)
            {
                var square = new Square(row + i, col - i);
                if (i != 0)
                {
                    moves.Add(square);
                }
            }
        }
        
    }
}