﻿using System;
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

        protected List<Square> addLateralMoves(Square currentSquare)
        {
            var row = currentSquare.Row;
            var col = currentSquare.Col;
            var moves = new List<Square>();
            
            for (var i = 0; i < GameSettings.BoardSize; i++)
            {
                var square = new Square(i, col);
                if (i != row)
                {
                    moves.Add(square);
                }
            }

            for (var j = 0; j < GameSettings.BoardSize; j++)
            {
                var square = new Square(row, j);
                if (j != col)
                {
                    moves.Add(square);
                }
            }

            return moves;
        }

        protected List<Square> AddKnightMoves(Square square)
        {
            var row = square.Row;
            var col = square.Col;
            var moves = new List<Square>();
            
            for (var i = -2; i <= 2; i++)
            {
                if (i != 0)
                {
                    moves.Add(new Square(row+i, col+(3 - Math.Abs(i))));
                    moves.Add(new Square(row+i, col-(3 - Math.Abs(i))));
                }
            }

            return moves;
        }
        
        protected List<Square> AddDiagonalMoves(Square currentSquare)
        {
            var row = currentSquare.Row;
            var col = currentSquare.Col;
            var moves = new List<Square>();
            
            for (var i = -Math.Min(row, col); i < Math.Max(GameSettings.BoardSize - row, GameSettings.BoardSize - col); i++)
            {
                var square = new Square(row + i, col + i);
                if (i != 0)
                {
                    moves.Add(square);
                }
            }
            
            for (var i = -Math.Min(row, GameSettings.BoardSize - 1 - col); i < Math.Max(GameSettings.BoardSize - row, col); i++)
            {
                var square = new Square(row + i, col - i);
                if (i != 0)
                {
                    moves.Add(square);
                }
            }

            return moves;
        }

        protected List<Square> AddKingMoves(Square square)
        {
            var row = square.Row;
            var col = square.Col;
            var moves = new List<Square>();

            for (var i = -1; i <= 1; i++)
            {
                for (var j = -1; j <= 1; j++)
                {
                    if (! (i == 0 && j == 0))
                    {
                        moves.Add(new Square(row + i, col + j));
                    }
                }
            }
            
            return moves;
        }
        
    }
}

// boardSize instead of 8