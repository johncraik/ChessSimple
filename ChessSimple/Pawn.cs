using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ChessSimple
{
    internal class Pawn : ChessPiece
    {
        private int id;
        private bool atStart;
        private bool atEnd;
        private int maxMove;

        /// <summary>
        /// Initialise new pawn.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="index"></param>
        /// <param name="atStart"></param>
        /// <param name="atEnd"></param>
        public Pawn(Point index, bool isWhite, int id, bool atStart, bool atEnd) : base(index, isWhite)
        {
            this.id = id;
            this.atStart = atStart;
            this.atEnd = atEnd;

            if (atStart == true)
            {
                this.maxMove = 2;
            }
            else
            {
                this.maxMove = 1;
            }  
        }

        /// <summary>
        /// Get the pawn ID
        /// </summary>
        /// <returns></returns>
        public int getID()
        {
            return id;
        }

        /// <summary>
        /// Get the atStart bool. True if at starting position.
        /// </summary>
        /// <returns></returns>
        public bool getAtStart()
        {
            return atStart;
        }

        /// <summary>
        /// Get the atEnd bool. True if pawn has reach the other end of the board.
        /// </summary>
        /// <returns></returns>
        public bool getAtEnd()
        {
            return atEnd;
        }

        /// <summary>
        /// Get the maximum squares the pawn can move.
        /// </summary>
        /// <returns></returns>
        public int getMaxMove()
        {
            return maxMove;
        }

        /// <summary>
        /// Set the atStart bool. True if at starting position.
        /// </summary>
        /// <param name="atStart"></param>
        public void setAtStart(bool atStart)
        {
            this.atStart = atStart;

            if (atStart == true)
            {
                this.maxMove = 2;
            }
            else
            {
                this.maxMove = 1;
            }
        }

        /// <summary>
        /// Set the atEnd bool. True if pawn has reach the other end of the board.
        /// </summary>
        /// <param name="atEnd"></param>
        public void setAtEnd(bool atEnd)
        {
            this.atEnd = atEnd;
        }

        /// <summary>
        /// Output pawn information as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string col = "White";
            if (getIsWhite() == false)
            {
                col = "Black";
            }

            return (col + " Pawn #" + this.id + " is at position: (" + getX() + ", " + getY() + ") " +
                "and can move a maximum of: " + this.maxMove + ". " +
                "At starting pos: " + this.atStart + ". " +
                "Reached end pos: " + this.atEnd);
        }


        public bool[,] movePawn(ChessPiece[,] board)
        {
            //Get the X and Y of the current pawn.
            int pX = this.getX();
            int pY = this.getY();
            bool[,] moveable = new bool[8, 8];

            int i = 0; int j = 0;
            foreach(ChessPiece p in board)
            {
                //Loop through the board.
                if (p != null && (i == pX + 1 || i == pX -1) && (j == pY -1 || j == pY +1))
                {
                    //If the chess piece is NOT null (occupied space)
                    //AND if the X is one to left OR right
                    //AND if the Y is one to top OR bottom
                    //THEN the pawn can move there (take the piece)
                    moveable[i, j] = true;
                }
                else if (p == null && ((i == pX + maxMove || i == pX - maxMove) && j == pY))
                {
                    //If the chess piece is null (empty space)
                    //AND the X is one or two (max) to the left OR right
                    //AND the Y is equal to the Y of the pawn
                    //THEN the pawn can move there (move to an empty space in front)
                    moveable[i, j] = true;
                }
                else
                {
                    //OTHERWISE the pawn CANNOT move.
                    moveable[i, j] = false;
                }

                //Increment Y axis:
                j++;
                if (j == 8)
                {
                    //If at the end of the board (j = 8),
                    //THEN reset the Y axis and increment the X axis.
                    j = 0;
                    i++;
                }
            }          

            //Return the 2D bool array of possible moveable spaces for the pawn.
            return moveable;
        }
    }
}
