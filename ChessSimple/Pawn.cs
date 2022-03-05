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

        public Pawn(int id, Point index, bool atStart, bool atEnd) : base(index)
        {
            this.id = id;
            this.atStart = atStart;
            this.atEnd = atEnd;
            this.maxMove = 1;
        }

        public int getID()
        {
            return id;
        }

        public bool getAtStart()
        {
            return atStart;
        }

        public bool getAtEnd()
        {
            return atEnd;
        }

        public int getMaxMove()
        {
            return maxMove;
        }

        public void setAtStart(bool atStart)
        {
            this.atStart = atStart;
        }

        public void setAtEnd(bool atEnd)
        {
            this.atEnd = atEnd;
        }

        public override string ToString()
        {
            return ("Pawn #" + this.id + " is at position: (" + getX() + ", " + getY() + ") " +
                "and can move a maximum of: " + this.maxMove + ". " +
                "At starting pos: " + this.atStart + ". " +
                "Reached end pos: " + this.atEnd);
        }
    }
}
