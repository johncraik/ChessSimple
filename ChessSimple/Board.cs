using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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


        public ChessPiece[,] createGame(bool ply1)
        {

            /*
             * NOTE: -- Front end under 'MainWindow.xaml.cs' file --
             * BACK END:
             */
            ChessPiece[,] board = new ChessPiece[8, 8];

            //Create player 1 (ply1) pieces on the left side.
            //Add back row pieces:
            int x = 0; int y = 0;
            int rook = 0; int knight = 0; int bishop = 0;

            board[x, y] = new Rook(new Point(x, y), ply1, rook); rook++; y++;       //Rook
            board[x, y] = new Knight(new Point(x, y), ply1, knight); knight++; y++; //Knight
            board[x, y] = new Bishop(new Point(x, y), ply1, bishop); bishop++; y++; //Bishop
            board[x, y] = new Queen(new Point(x, y), ply1, 0); y++;                 //Queen
            board[x, y] = new King(new Point(x, y), ply1, 0, false, false); y++;    //King
            board[x, y] = new Bishop(new Point(x, y), ply1, bishop); bishop++; y++; //Bishop
            board[x, y] = new Knight(new Point(x, y), ply1, knight); knight++; y++; //Knight
            board[x, y] = new Rook(new Point(x, y), ply1, rook); rook++; y++;       //Rook


            //Add pawns:
            x = 1; y = 0;
            for (int i = 0; i < 8; i++)
            {
                board[x, y] = new Pawn(new Point(x,y), ply1, i, true, true, false);
                y++;
            }


            //Create player 2 (ply2) pieces on the right side.
            bool ply2 = !ply1;

            //Add pawns:
            x = 6; y = 0;
            for (int i = 0; i < 8; i++)
            {
                board[x, y] = new Pawn(new Point(x, y), ply2, i, false, true, false);
                y++;
            }

            //Add back row pieces:
            x = 7; y = 0;
            rook = 0; knight = 0; bishop = 0;

            board[x, y] = new Rook(new Point(x, y), ply2, rook); rook++; y++;       //Rook
            board[x, y] = new Knight(new Point(x, y), ply2, knight); knight++; y++; //Knight
            board[x, y] = new Bishop(new Point(x, y), ply2, bishop); bishop++; y++; //Bishop
            board[x, y] = new Queen(new Point(x, y), ply2, 0); y++;                 //Queen
            board[x, y] = new King(new Point(x, y), ply2, 0, false, false); y++;    //King
            board[x, y] = new Bishop(new Point(x, y), ply2, bishop); bishop++; y++; //Bishop
            board[x, y] = new Knight(new Point(x, y), ply2, knight); knight++; y++; //Knight
            board[x, y] = new Rook(new Point(x, y), ply2, rook); rook++; y++;       //Rook

            return board;
        }

        public void createMoveableSqrs(bool[,] moveable, Grid board)
        {
            int i = 0; int j = 0;
            foreach(bool move in moveable)
            {
                if (move == true)
                {
                    Button btn = new();
                    btn.Name = "Btn_Test";
                    btn.Background = new SolidColorBrush(Color.FromRgb(255,0,0));
                    board.Children.Add(btn);
                    Grid.SetColumn(btn, i);
                    Grid.SetRow(btn, j);
                }

                //Increment Y axis:
                j++;
                if (j == 8)
                {
                    //If at the end of the board (j = 8),
                    //THEN reset the Y axis and increment the X axis.
                    j = 0;
                    i++;
                }
            }
        }
    }
}
