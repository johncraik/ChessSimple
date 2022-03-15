using System;
using System.Collections.Generic;
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
            ChessPiece[,] board = Board.createGame(true);
            Pawn test = (Pawn) board[6, 5];

            test.movePawn(board);

            

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void Btn_Quit_Click(object sender, RoutedEventArgs e)
        {
            //Quit the app if they click 'Yes' on the message box.
            if (MessageBox.Show("Are you sure you want to quit?", "Quit Game", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
