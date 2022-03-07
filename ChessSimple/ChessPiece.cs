using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ChessSimple
{
    internal class ChessPiece
    {
        private Point index;
        private bool isWhite;

        /// <summary>
        /// Initialise new chess piece.
        /// </summary>
        /// <param name="index"></param>
        public ChessPiece(Point index, bool isWhite)
        {
            this.index = index;
            this.isWhite = isWhite;
        }

        /// <summary>
        /// Get the XY index of the chess piece. (-1,-1) if not on board.
        /// </summary>
        /// <returns></returns>
        public Point getIndex()
        {
            return index;
        }

        /// <summary>
        /// Get the X index for the chess piece.
        /// </summary>
        /// <returns></returns>
        public int getX()
        {
            return Convert.ToInt32(index.X);
        }

        /// <summary>
        /// Get the Y index for the chess piece.
        /// </summary>
        /// <returns></returns>
        public int getY()
        {
            return Convert.ToInt32(index.Y);
        }

        /// <summary>
        /// Get the bool isWhite. True if on white team, false if on black team.
        /// </summary>
        /// <returns></returns>
        public bool getIsWhite()
        {
            return isWhite;
        }

        /// <summary>
        /// Set the XY index of the chess piece. (-1,-1) if not on board.
        /// </summary>
        /// <param name="index"></param>
        public void setIndex(Point index)
        {
            this.index = index;
        }

        /// <summary>
        /// Set the bool isWhite. True if on white team, false if on black team.
        /// </summary>
        /// <param name="isWhite"></param>
        public void setIsWhite(bool isWhite)
        {
            this.isWhite = isWhite;
        }

        /// <summary>
        /// Output limited information on the chess piece.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ("Chess piece with position: (" + getIndex() + ")");
        }
    }
}
