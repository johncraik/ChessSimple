using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ChessSimple
{
    internal static class Res
    {
        public static SolidColorBrush blk_Board = new SolidColorBrush(Color.FromRgb(84, 153, 104));
        public static SolidColorBrush wht_Board = new SolidColorBrush(Color.FromRgb(230, 230, 230));


        public const string blk_Pawn = "\u265F";
        public const string blk_Rook = "\u265C";
        public const string blk_Bishop = "\u265D";
        public const string blk_Knight = "\u265E";
        public const string blk_Queen = "\u265B";
        public const string blk_King = "\u265A";

        public const string wht_Pawn = "\u2659";
        public const string wht_Rook = "\u2656";
        public const string wht_Bishop = "\u2657";
        public const string wht_Knight = "\u2658";
        public const string wht_Queen = "\u2655";
        public const string wht_King = "\u2654";

        public static OleDbConnection? DbConnection()
        {
            try
            {
                //Get the current directory of the database:
                string path = Environment.CurrentDirectory;
                int index = path.IndexOf("ChessSimple");
                path = path.Substring(0, index) + @"ChessSimple\ChessSimple\resources\Db_ChessSimple.accdb";
                
                //Connecttion String:
                string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path +";Persist Security Info=True";
                OleDbConnection conDb = new OleDbConnection(conString);

                try
                {
                    conDb.Open();
                    Console.WriteLine("Connection was successful.");
                    return conDb;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected Error has occured. The database could not be opened." +
                    "\n----------------------------------\nDetails:\n" + ex.Message);
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error has occured. Connection string may be invalid." +
                    "\n----------------------------------\nDetails:\n" + ex.Message);
                return null;
            }
        }
    }
}
