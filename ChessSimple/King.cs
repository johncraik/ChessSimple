using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessSimple
{
    internal class King : ChessPiece
    {
        private int id;
        private bool mate;
        private bool check;

        /// <summary>
        /// Initialise new queen.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="index"></param>
        /// <param name="atStart"></param>
        /// <param name="atEnd"></param>
        public King(Point index, bool isWhite, int id, bool mate, bool check) : base(index, isWhite)
        {
            this.id = id; 
            this.mate = mate;
            this.check = check; 
        }

        /// <summary>
        /// Get the king ID
        /// </summary>
        /// <returns></returns>
        public int getID()
        {
            return id;
        }

        /// <summary>
        /// Get the mate value of the king. True if the king is in mate.
        /// </summary>
        /// <returns></returns>
        public bool getMate()
        {
            return mate;
        }

        /// <summary>
        /// Get the check value of the king. True if the king is in check mate.
        /// </summary>
        /// <returns></returns>
        public bool getCheck()
        {
            return check;
        }

        /// <summary>
        /// Set the mate value of the king. True if the king is in mate.
        /// </summary>
        /// <param name="mate"></param>
        public void setMate(bool mate)
        {
            this.mate = mate;
        }

        /// <summary>
        /// Set the check value of the king. True if the king is in check mate.
        /// </summary>
        /// <param name="check"></param>
        public void setCheck(bool check)
        {
            this.check = check;
        }

        /// <summary>
        /// Output king information as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string col = "White";
            if (getIsWhite() == false)
            {
                col = "Black";
            }

            return (col + " king #" + this.id + " is at position: (" + getX() + ", " + getY() + "). " +
                "In mate: " + this.mate + ". In check: " + this.check + ".");
        }
    }
}
