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

        public ChessPiece(Point index)
        {
            this.index = index;
        }

        public Point getIndex()
        {
            return index;
        }

        public void setIndex(Point index)
        {
            this.index = index;
        }
    }
}
