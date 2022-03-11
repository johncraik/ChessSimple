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
    }
}
