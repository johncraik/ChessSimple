using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessSimple
{
    internal class Board
    {
        private bool active;

        /// <summary>
        /// Initialise new board.
        /// </summary>
        /// <param name="active"></param>
        public Board(bool active)
        {
            this.active = active;
        }

        /// <summary>
        /// Returns the bool active. True when game is running, false otherwise.
        /// </summary>
        /// <returns></returns>
        public bool getActive()
        {
            return this.active;
        }

        /// <summary>
        /// Set the bool active. True when game is running, false otherwise.
        /// </summary>
        /// <param name="active"></param>
        public void setActive(bool active)
        {
            this.active = active;
        }


        public static ChessPiece[,] createGame(bool ply1)
        {
            ChessPiece[,] board = new ChessPiece[8,8];

            //Create player 1 (ply1) pieces on the left side.
            int x = 1;
            int y = 0;

            //Add pawns:
            for (int i = 0; i < 8; i++)
            {
                board[x, y] = new Pawn(new Point(x,y), ply1, i, true, false);
                y++;
            }

            return board;
        }
    }
}
