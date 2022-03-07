using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessSimple
{
    internal class ChessPiece
    {
        private Point index;

        /// <summary>
        /// Initialise new chess piece.
        /// </summary>
        /// <param name="index"></param>
        public ChessPiece(Point index)
        {
            this.index = index;
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
        /// Set the XY index of the chess piece. (-1,-1) if not on board.
        /// </summary>
        /// <param name="index"></param>
        public void setIndex(Point index)
        {
            this.index = index;
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
