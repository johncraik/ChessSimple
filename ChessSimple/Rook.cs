using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessSimple
{
    internal class Rook : ChessPiece
    {
        private int id;

        /// <summary>
        /// Initialise new rook.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="index"></param>
        /// <param name="atStart"></param>
        /// <param name="atEnd"></param>
        public Rook(Point index, bool isWhite, int id) : base(index, isWhite)
        {
            this.id = id; 
        }

        /// <summary>
        /// Get the rook ID
        /// </summary>
        /// <returns></returns>
        public int getID()
        {
            return id;
        }

        /// <summary>
        /// Output rook information as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string col = "White";
            if (getIsWhite() == false)
            {
                col = "Black";
            }

            return (col + " rook #" + this.id + " is at position: (" + getX() + ", " + getY() + ")");
        }

        public bool[,] moveRook(ChessPiece[,] board)
        {
            //Get the X and Y of the current bishop.
            int pX = this.getX();
            int pY = this.getY();
            bool[,] moveable = new bool[8, 8];

            int i = 0; int j = 0; 
            int iMax = 7 - pX; int jMax = 7 - pY;
            foreach (ChessPiece p in board)
            {
                //Loop through the board.
                if (i == pX || j == pY)
                {

                }


                if (p.getIsWhite() != this.getIsWhite())
                {
                    if (i == pX || j == pY)
                    {
                        moveable[i, j] = true;
                    }

                }
                else
                {
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

            //Return the 2D bool array of possible moveable spaces for the bishop.
            return moveable;
        }
    }
}
