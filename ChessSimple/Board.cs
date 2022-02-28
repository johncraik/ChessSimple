using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessSimple
{
    internal class Board
    {
        private bool active;

        /// <summary>
        /// Initialise new board.
        /// </summary>
        /// <param name="active"></param>
        public Board(bool active)
        {
            this.active = active;
        }

        /// <summary>
        /// Returns the bool active. True when game is running, false otherwise.
        /// </summary>
        /// <returns></returns>
        public bool getActive()
        {
            return this.active;
        }

        /// <summary>
        /// Set the bool active. True when game is running, false otherwise.
        /// </summary>
        /// <param name="active"></param>
        public void setActive(bool active)
        {
            this.active = active;
        }
    }
}
