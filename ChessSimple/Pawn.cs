using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public Pawn(int id, Point index, bool atStart, bool atEnd) : base(index)
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
            return ("Pawn #" + this.id + " is at position: (" + getX() + ", " + getY() + ") " +
                "and can move a maximum of: " + this.maxMove + ". " +
                "At starting pos: " + this.atStart + ". " +
                "Reached end pos: " + this.atEnd);
        }
    }
}
