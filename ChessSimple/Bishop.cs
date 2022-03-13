using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessSimple
{
    internal class Bishop : ChessPiece
    {
        private int id;

        /// <summary>
        /// Initialise new bishop.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="index"></param>
        /// <param name="atStart"></param>
        /// <param name="atEnd"></param>
        public Bishop(Point index, bool isWhite, int id) : base(index, isWhite)
        {
            this.id = id; 
        }

        /// <summary>
        /// Get the bishop ID
        /// </summary>
        /// <returns></returns>
        public int getID()
        {
            return id;
        }

        /// <summary>
        /// Output bishop information as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string col = "White";
            if (getIsWhite() == false)
            {
                col = "Black";
            }

            return (col + " Bishop #" + this.id + " is at position: (" + getX() + ", " + getY() + ")");
        }


        public bool[,] moveBishop(ChessPiece[,] board)
        {
            //Get the X and Y of the current bishop.
            int pX = this.getX();
            int pY = this.getY();
            bool[,] moveable = new bool[8, 8];

            int i = 0; int j = 0; int k = 1;
            foreach (ChessPiece p in board)
            {
                //Loop through the board.
                if (p == null)
                {

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

                //Reset k:
                k = i + j;
            }

            //Return the 2D bool array of possible moveable spaces for the bishop.
            return moveable;
        }
    }
}
