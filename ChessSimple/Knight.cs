using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessSimple
{
    internal class Knight : ChessPiece
    {
        private int id;

        /// <summary>
        /// Initialise new knight.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="index"></param>
        /// <param name="atStart"></param>
        /// <param name="atEnd"></param>
        public Knight(Point index, bool isWhite, int id) : base(index, isWhite)
        {
            this.id = id; 
        }

        /// <summary>
        /// Get the knight ID
        /// </summary>
        /// <returns></returns>
        public int getID()
        {
            return id;
        }

        /// <summary>
        /// Output knight information as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string col = "White";
            if (getIsWhite() == false)
            {
                col = "Black";
            }

            return (col + " knight #" + this.id + " is at position: (" + getX() + ", " + getY() + ")");
        }
    }
}
