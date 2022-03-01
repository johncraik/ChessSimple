using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ChessSimple
{
    internal class Square : Board
    {
        private Canvas sqr;
        private Point index;
        private ChessPiece piece;

        /// <summary>
        /// Constructor to define a new square.
        /// </summary>
        /// <param name="active"></param>
        /// <param name="sqr"></param>
        /// <param name="index"></param>
        /// <param name="piece"></param>
        public Square(bool active, Canvas sqr, Point index, ChessPiece piece) : base(active)
        {
            this.sqr = sqr;
            this.index = index;
            this.piece = piece;
        }

        /// <summary>
        /// Get the corresponding canvas on the UI.
        /// </summary>
        /// <returns></returns>
        public Canvas getSquare()
        {
            return sqr;
        }

        /// <summary>
        /// Get the XY index for the square.
        /// </summary>
        /// <returns></returns>
        public Point getIndex()
        {
            return index;
        }

        /// <summary>
        /// Get the X index for the square.
        /// </summary>
        /// <returns></returns>
        public int getX()
        {
            return (int) index.X;
        }

        /// <summary>
        /// Get the Y index for the square.
        /// </summary>
        /// <returns></returns>
        public int getY()
        {
            return (int) index.Y;
        }

        /// <summary>
        /// Get the current chess piece on the square. Null if empty.
        /// </summary>
        /// <returns></returns>
        public ChessPiece getChessPiece()
        {
            return piece;
        }

        /// <summary>
        /// Assign the corresponding canvas to the square object.
        /// </summary>
        /// <param name="sqr"></param>
        public void setSquare(Canvas sqr)
        {
            this.sqr = sqr;
        }

        /// <summary>
        /// Set the XY index of the square.
        /// </summary>
        /// <param name="index"></param>
        public void setIndex(Point index)
        {
            this.index = index;
        }

        /// <summary>
        /// Set the chess piece on the square.
        /// </summary>
        /// <param name="piece"></param>
        public void setChessPiece(ChessPiece piece)
        {
            this.piece = piece;
        }
    }
}
