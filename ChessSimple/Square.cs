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

        public Square(bool active, Canvas sqr, Point index, ChessPiece piece) : base(active)
        {
            this.sqr = sqr;
            this.index = index;
            this.piece = piece;
        }

        public Canvas getSquare()
        {
            return sqr;
        }

        public Point getIndex()
        {
            return index;
        }

        public int getX()
        {
            return (int) index.X;
        }

        public int getY()
        {
            return (int) index.Y;
        }

        public ChessPiece getChessPiece()
        {
            return piece;
        }

        public void setSquare(Canvas sqr)
        {
            this.sqr = sqr;
        }

        public void setIndex(Point index)
        {
            this.index = index;
        }

        public void setChessPiece(ChessPiece piece)
        {
            this.piece = piece;
        }
    }
}
