using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Resources;

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

        protected List<Square> AddLateralMoves(Square currentSquare, Board board, Player player)
        {
            var row = currentSquare.Row;
            var col = currentSquare.Col;
            var moves = new List<Square>();
            
            // Move downwards
            for (var i = row + 1; i < GameSettings.BoardSize; i++)
            {
                var square = new Square(i, col);
                if (board.GetPiece(square) != null)
                {
                    if (board.GetPiece(square).Player != player)
                    {
                        moves.Add(square);
                    }
                    break;
                }
                moves.Add(square);
            }
            
            // Move upwards
            for (var i = row - 1; i >= 0; i--)
            {
                var square = new Square(i, col);
                if (board.GetPiece(square) != null)
                {
                    if (board.GetPiece(square).Player != player)
                    {
                        moves.Add(square);
                    }
                    break;
                }
                moves.Add(square);
            }

            // Move rightwards 
            for (var j = col + 1; j < GameSettings.BoardSize; j++)
            {
                var square = new Square(row, j);
                if (board.GetPiece(square) != null)
                {
                    if (board.GetPiece(square).Player != player)
                    {
                        moves.Add(square);
                    }
                    break;
                }
                moves.Add(square);
            }
            
            // Move leftwards
            for (var j = col - 1; j >= 0; j--)
            {
                var square = new Square(row, j);
                if (board.GetPiece(square) != null)
                {
                    if (board.GetPiece(square).Player != player)
                    {
                        moves.Add(square);
                    }
                    break;
                }
                moves.Add(square);
            }

            return moves;
        }

        protected List<Square> AddKnightMoves(Square currentSquare)
        {
            var row = currentSquare.Row;
            var col = currentSquare.Col;
            var moves = new List<Square>();
            
            for (var i = -2; i <= 2; i++)
            {
                if (i != 0)
                {
                    var square = new Square(row+i, col+(3 - Math.Abs(i)));
                    if (square.IsWithinBoard())
                    {
                        moves.Add(square);
                    }

                    square = new Square(row + i, col - (3 - Math.Abs(i)));
                    if (square.IsWithinBoard())
                    {
                        moves.Add(square);
                    }
                }
            }

            return moves;
        }
        
        protected List<Square> AddDiagonalMoves(Square currentSquare, Board board, Player player)
        {
            var row = currentSquare.Row;
            var col = currentSquare.Col;
            var moves = new List<Square>();
            
            /* Limits (all strict):
             * upper-left: Math.Min(row + 1, col + 1)
             * upper-right: Math.Min(row + 1, GameSettings.BoardSize - col)
             * lower-right: Math.Min(GameSettings.BoardSize - row, GameSettings.BoardSize - col
             * lower-left: Math.Min(GameSettings.BoardSize - row, col + 1)
             */
            
            // Move towards bottom right
            for (var i = 1; i < Math.Min(GameSettings.BoardSize - row, GameSettings.BoardSize - col); i++)
            {
                var square = new Square(row + i, col + i);
                if (board.GetPiece(square) != null)
                {
                    if (board.GetPiece(square).Player != player)
                    {
                        moves.Add(square);
                    }
                    break;
                }
                moves.Add(square);
            }
            
            // Move towards bottom left
            for (var i = 1; i < Math.Min(GameSettings.BoardSize - row, col + 1); i++)
            {
                var square = new Square(row + i, col - i);
                if (board.GetPiece(square) != null)
                {
                    if (board.GetPiece(square).Player != player)
                    {
                        moves.Add(square);
                    }
                    break;
                }
                moves.Add(square);
            }
            
            // Move towards top left
            for (var i = 1; i < Math.Min(row + 1, col + 1); i++)
            {
                var square = new Square(row - i, col - i);
                if (board.GetPiece(square) != null)
                {
                    if (board.GetPiece(square).Player != player)
                    {
                        moves.Add(square);
                    }
                    break;
                }
                moves.Add(square);
            }
            
            // Move towards top right
            for (var i = 1; i < Math.Min(row + 1, GameSettings.BoardSize - col); i++)
            {
                var square = new Square(row - i, col + i);
                if (board.GetPiece(square) != null)
                {
                    if (board.GetPiece(square).Player != player)
                    {
                        moves.Add(square);
                    }
                    break;
                }
                moves.Add(square);
            }

            return moves;
        }

        protected List<Square> AddKingMoves(Square currentSquare)
        {
            var row = currentSquare.Row;
            var col = currentSquare.Col;
            var moves = new List<Square>();

            for (var i = -1; i <= 1; i++)
            {
                for (var j = -1; j <= 1; j++)
                {
                    if (! (i == 0 && j == 0))
                    {
                        var square = new Square(row + i, col + j);
                        if (square.IsWithinBoard())
                        {
                            moves.Add(square);
                        }
                    }
                }
            }
            
            return moves;
        }

    }
}