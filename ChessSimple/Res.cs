using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace ChessSimple
{
    internal static class Res
    {
        //Chess board colours:
        public static SolidColorBrush blk_Board = new SolidColorBrush(Color.FromRgb(84, 153, 104));
        public static SolidColorBrush wht_Board = new SolidColorBrush(Color.FromRgb(230, 230, 230));

        //Unicode for all the chess pieces:
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

        /// <summary>
        /// Connect to external database. Will return a connection if successful. Null if an error occured.
        /// </summary>
        /// <returns></returns>
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
                    //Open the database connection:
                    conDb.Open();
                    Console.WriteLine("Connection was successful.");
                    return conDb;
                }
                catch (Exception ex)
                {
                    //If an error occurs, output to the console:
                    Console.WriteLine("Unexpected Error has occured. The database could not be opened." +
                    "\n----------------------------------\nDetails:\n" + ex.Message);
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                //If an error occurs, output to the console:
                Console.WriteLine("Unexpected Error has occured. Connection string may be invalid." +
                    "\n----------------------------------\nDetails:\n" + ex.Message);
                return null;
            }
        }

        public static void DbAddNewPlayer(OleDbConnection conDb, string ply)
        {
            OleDbCommand cmd = null;
            OleDbDataReader rdr = null;

            try
            {
                /*
                 * SEARCH CURRENT PLAYERS:
                 * (Cannot have duplicate players)
                 */
                cmd = new OleDbCommand("SELECT * FROM Tbl_Players;", conDb);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.GetString(1) == ply)
                    {
                        //If player already exists, do nothing (return).
                        Console.WriteLine("Player already added to database.");
                        return;
                    }
                }

                /*
                 * ADD NEW PLAYER:
                 * (If the player does not exist, add them)
                 */
                cmd = new OleDbCommand("INSERT INTO Tbl_Players (PlyName) VALUES ('" + ply + "');", conDb);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Player added to database successfully.");
            }
            catch (Exception ex)
            {
                //If an error occurs, output to the console:
                Console.WriteLine("Unexpected Error has occured." +
                    "\n----------------------------------\nDetails:\n" + ex.Message);
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (rdr != null) rdr.Close();
            }
        }
    }
}
