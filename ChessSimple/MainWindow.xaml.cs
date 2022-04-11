using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessSimple
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_StartStop_Click(object sender, RoutedEventArgs e)
        {
            string player1 = "ERROR - NO PLAYER";
            string player2 = "ERROR - NO PLAYER";
            bool ply1White = true;
            Tb_ply1.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            Tb_ply2.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            try
            {
#pragma warning disable CS8629 // Nullable value type may be null.
                ply1White = (bool) Rb_Wply1.IsChecked;
#pragma warning restore CS8629 // Nullable value type may be null.

                if (Tb_ply1.Text != "")
                {
                    //If player 1 text box is not empty, store the name:
                    player1 = Tb_ply1.Text;
                }
                else
                {
                    //If player 1 text box is empty, return an error:
                    Tb_ply1.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    MessageBox.Show("Please enter in valid name for player 1.", "Player 1 Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (Tb_ply2.Text != "")
                {
                    //If player 2 text box is not empty, store the name:
                    player2 = Tb_ply2.Text;
                }
                else
                {
                    //If player 2 text box is empty, return an error:
                    Tb_ply2.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    MessageBox.Show("Please enter in valid name for player 2.", "Player 2 Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                //If an error occurs, output to the user:
                MessageBox.Show("An unexpected error has occured. \n--------------------------- \nDetails: \n" + ex.Message, 
                    "Player Colour Selection Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            /*
             * CREATE NEW GAME:
             * 1) Initialise new object as board [active = true]
             * 2) Create a new game using 'createGame' func [pl1White = local variable]
             * 3) Config player colours based on ply1White
             */
            Board newGame = new(true);
            ChessPiece[,] board = newGame.createGame(ply1White);
            ConfigColours(ply1White);
            OleDbConnection dbConnection = Res.DbConnection();

            if (dbConnection != null)
            {

            }
        }

        private void Btn_Quit_Click(object sender, RoutedEventArgs e)
        {
            //Quit the app if they click 'Yes' on the message box.
            if (MessageBox.Show("Are you sure you want to quit?", "Quit Game", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        //Front end for chess pieces:
        private void ConfigColours(bool white)
        {
            if (white)
            {
                /*
                 * PLAYER 1:
                 */
                //Pawns:
                Txt_Ply1Pawn0.Text = Res.wht_Pawn; Txt_Ply1Pawn0.FontSize = 100;
                Txt_Ply1Pawn1.Text = Res.wht_Pawn; Txt_Ply1Pawn1.FontSize = 100;
                Txt_Ply1Pawn2.Text = Res.wht_Pawn; Txt_Ply1Pawn2.FontSize = 100;
                Txt_Ply1Pawn3.Text = Res.wht_Pawn; Txt_Ply1Pawn3.FontSize = 100;
                Txt_Ply1Pawn4.Text = Res.wht_Pawn; Txt_Ply1Pawn4.FontSize = 100;
                Txt_Ply1Pawn5.Text = Res.wht_Pawn; Txt_Ply1Pawn5.FontSize = 100;
                Txt_Ply1Pawn6.Text = Res.wht_Pawn; Txt_Ply1Pawn6.FontSize = 100;
                Txt_Ply1Pawn7.Text = Res.wht_Pawn; Txt_Ply1Pawn7.FontSize = 100;
                //Rooks:
                Txt_Ply1Rook1.Text = Res.wht_Rook;
                Txt_Ply1Rook2.Text = Res.wht_Rook;
                //Knights:
                Txt_Ply1Knight1.Text = Res.wht_Knight;
                Txt_Ply1Knight2.Text = Res.wht_Knight;
                //Bishops:
                Txt_Ply1Bishop1.Text = Res.wht_Bishop;
                Txt_Ply1Bishop2.Text = Res.wht_Bishop;
                //Queen:
                Txt_Ply1Queen.Text = Res.wht_Queen;
                //King:
                Txt_Ply1King.Text = Res.wht_King;

                /*
                 * PLAYER 2:
                 */
                //Pawns:
                Txt_Ply2Pawn0.Text = Res.blk_Pawn; Txt_Ply2Pawn0.FontSize = 70;
                Txt_Ply2Pawn1.Text = Res.blk_Pawn; Txt_Ply2Pawn1.FontSize = 70;
                Txt_Ply2Pawn2.Text = Res.blk_Pawn; Txt_Ply2Pawn2.FontSize = 70;
                Txt_Ply2Pawn3.Text = Res.blk_Pawn; Txt_Ply2Pawn3.FontSize = 70;
                Txt_Ply2Pawn4.Text = Res.blk_Pawn; Txt_Ply2Pawn4.FontSize = 70;
                Txt_Ply2Pawn5.Text = Res.blk_Pawn; Txt_Ply2Pawn5.FontSize = 70;
                Txt_Ply2Pawn6.Text = Res.blk_Pawn; Txt_Ply2Pawn6.FontSize = 70;
                Txt_Ply2Pawn7.Text = Res.blk_Pawn; Txt_Ply2Pawn7.FontSize = 70;
                //Rooks:
                Txt_Ply2Rook1.Text = Res.blk_Rook;
                Txt_Ply2Rook2.Text = Res.blk_Rook;
                //Knights:
                Txt_Ply2Knight1.Text = Res.blk_Knight;
                Txt_Ply2Knight2.Text = Res.blk_Knight;
                //Bishops:
                Txt_Ply2Bishop1.Text = Res.blk_Bishop;
                Txt_Ply2Bishop2.Text = Res.blk_Bishop;
                //Queen:
                Txt_Ply2Queen.Text = Res.blk_Queen;
                //King:
                Txt_Ply2King.Text = Res.blk_King;
            }
            else
            {
                /*
                 * PLAYER 1:
                 */
                //Pawns:
                Txt_Ply1Pawn0.Text = Res.blk_Pawn; Txt_Ply1Pawn0.FontSize = 70;
                Txt_Ply1Pawn1.Text = Res.blk_Pawn; Txt_Ply1Pawn1.FontSize = 70;
                Txt_Ply1Pawn2.Text = Res.blk_Pawn; Txt_Ply1Pawn2.FontSize = 70;
                Txt_Ply1Pawn3.Text = Res.blk_Pawn; Txt_Ply1Pawn3.FontSize = 70;
                Txt_Ply1Pawn4.Text = Res.blk_Pawn; Txt_Ply1Pawn4.FontSize = 70;
                Txt_Ply1Pawn5.Text = Res.blk_Pawn; Txt_Ply1Pawn5.FontSize = 70;
                Txt_Ply1Pawn6.Text = Res.blk_Pawn; Txt_Ply1Pawn6.FontSize = 70;
                Txt_Ply1Pawn7.Text = Res.blk_Pawn; Txt_Ply1Pawn7.FontSize = 70;
                //Rooks:
                Txt_Ply1Rook1.Text = Res.blk_Rook;
                Txt_Ply1Rook2.Text = Res.blk_Rook;
                //Knights:
                Txt_Ply1Knight1.Text = Res.blk_Knight;
                Txt_Ply1Knight2.Text = Res.blk_Knight;
                //Bishops:
                Txt_Ply1Bishop1.Text = Res.blk_Bishop;
                Txt_Ply1Bishop2.Text = Res.blk_Bishop;
                //Queen:
                Txt_Ply1Queen.Text = Res.blk_Queen;
                //King:
                Txt_Ply1King.Text = Res.blk_King;

                /*
                 * PLAYER 1:
                 */
                //Pawns:
                Txt_Ply2Pawn0.Text = Res.wht_Pawn; Txt_Ply2Pawn0.FontSize = 100;
                Txt_Ply2Pawn1.Text = Res.wht_Pawn; Txt_Ply2Pawn1.FontSize = 100;
                Txt_Ply2Pawn2.Text = Res.wht_Pawn; Txt_Ply2Pawn2.FontSize = 100;
                Txt_Ply2Pawn3.Text = Res.wht_Pawn; Txt_Ply2Pawn3.FontSize = 100;
                Txt_Ply2Pawn4.Text = Res.wht_Pawn; Txt_Ply2Pawn4.FontSize = 100;
                Txt_Ply2Pawn5.Text = Res.wht_Pawn; Txt_Ply2Pawn5.FontSize = 100;
                Txt_Ply2Pawn6.Text = Res.wht_Pawn; Txt_Ply2Pawn6.FontSize = 100;
                Txt_Ply2Pawn7.Text = Res.wht_Pawn; Txt_Ply2Pawn7.FontSize = 100;
                //Rooks:
                Txt_Ply2Rook1.Text = Res.wht_Rook;
                Txt_Ply2Rook2.Text = Res.wht_Rook;
                //Knights:
                Txt_Ply2Knight1.Text = Res.wht_Knight;
                Txt_Ply2Knight2.Text = Res.wht_Knight;
                //Bishops:
                Txt_Ply2Bishop1.Text = Res.wht_Bishop;
                Txt_Ply2Bishop2.Text = Res.wht_Bishop;
                //Queen:
                Txt_Ply2Queen.Text = Res.wht_Queen;
                //King:
                Txt_Ply2King.Text = Res.wht_King;
            }
            
        }


        //Check Boxes:
        private void Rb_Wply1_Click(object sender, RoutedEventArgs e)
        {
            if(Rb_Wply1.IsChecked == true)
            {
                Rb_Bply1.IsChecked = false;

                Rb_Wply2.IsChecked = false;
                Rb_Bply2.IsChecked = true;
            }
            else
            {
                Rb_Bply1.IsChecked = true;

                Rb_Wply2.IsChecked = true;
                Rb_Bply2.IsChecked = false;
            }
        }

        private void Rb_Bply1_Click(object sender, RoutedEventArgs e)
        {
            if (Rb_Bply1.IsChecked == true)
            {
                Rb_Wply1.IsChecked = false;

                Rb_Bply2.IsChecked = false;
                Rb_Wply2.IsChecked = true;
            }
            else
            {
                Rb_Wply1.IsChecked = true;

                Rb_Bply2.IsChecked = true;
                Rb_Wply2.IsChecked = false;
            }
        }

        private void Rb_Wply2_Click(object sender, RoutedEventArgs e)
        {
            if (Rb_Wply2.IsChecked == true)
            {
                Rb_Bply2.IsChecked = false;

                Rb_Wply1.IsChecked = false;
                Rb_Bply1.IsChecked = true;
            }
            else
            {
                Rb_Bply2.IsChecked = true;

                Rb_Wply1.IsChecked = true;
                Rb_Bply1.IsChecked = false;
            }
        }

        private void Rb_Bply2_Click(object sender, RoutedEventArgs e)
        {
            if (Rb_Bply2.IsChecked == true)
            {
                Rb_Wply2.IsChecked = false;

                Rb_Bply1.IsChecked = false;
                Rb_Wply1.IsChecked = true;
            }
            else
            {
                Rb_Wply2.IsChecked = true;

                Rb_Bply1.IsChecked = true;
                Rb_Wply1.IsChecked = false;
            }
        }
    }
}
