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
        /// Set the XY index of the chess piece. (-1,-1) if not on board.
        /// </summary>
        /// <param name="index"></param>
        public void setIndex(Point index)
        {
            this.index = index;
        }
    }
}
