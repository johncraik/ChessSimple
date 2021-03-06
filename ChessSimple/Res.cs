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

        //Global Variables:
        public static Board game = new (false);
        public static ChessPiece[,] board = new ChessPiece[8,8];
        public static string player1 = "ERROR - NO PLAYER";
        public static string player2 = "ERROR - NO PLAYER";
        public static bool ply1White = true;

        //Global Funcs:
        public static Pawn? findPawn(ChessPiece[,] board, int id, bool ply1)
        {
            Pawn pawn = null;
            int i = 0; int j = 0;
            foreach(ChessPiece p in board)
            {
                try
                {
                    pawn = (Pawn)p;
                    if (pawn != null)
                    {
                        if (pawn.getID() == id && pawn.getIsWhite() == ply1)
                        {
                            return pawn;
                        }
                    }
                }
                catch 
                {
                    Console.WriteLine("Piece is not a pawn.");
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

            return pawn;
        }


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

        /// <summary>
        /// Get the ID of the player.
        /// </summary>
        /// <param name="conDb"></param>
        /// <param name="ply"></param>
        /// <returns></returns>
        public static int DbGetPlayerID(OleDbConnection conDb, string ply)
        {
            OleDbCommand cmd = null;
            OleDbDataReader rdr = null;

            try
            {
                /*
                 * SEARCH CURRENT PLAYERS:
                 * (Cannot have duplicate players)
                 */
                cmd = new OleDbCommand("SELECT * FROM Tbl_Players WHERE PlyName = '" + ply + "';", conDb);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = rdr.GetInt32(0);
                    string name = rdr.GetString(1);
                    if (name == ply)
                    {
                        return id;
                    }
                }
            }
            catch (Exception ex)
            {
                //If an error occurs, output to the console:
                Console.WriteLine("Unexpected Error has occured." +
                    "\n----------------------------------\nDetails:\n" + ex.Message);
                return -1;
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (rdr != null) rdr.Close();
            }
            return -1; //Not in database
        }

        /// <summary>
        /// Add a new player to the database.
        /// </summary>
        /// <param name="conDb"></param>
        /// <param name="ply"></param>
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
                int player = DbGetPlayerID(conDb, ply);
                if (player != -1)
                {
                    Console.WriteLine("Player already exists in database.");
                    return;
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
