using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace HoloEnglishData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection sqliteConnection;
            sqliteConnection = CreateConnection();
            CreateTable(sqliteConnection);
            InsertData(sqliteConnection);
            ReadData(sqliteConnection);
        }

        //set up connection
        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqliteConn;
            sqliteConn = new SQLiteConnection("Data Source=C:\\Users\\goper\\source\\repos\\HololiveQuery\\NewFolder1\\Databased\\HololiveQuery.db; Version = 3; New = True; Compress = True;");
            try
            {
                sqliteConn.Open();
            }
            catch
            {

            }
            return sqliteConn;
        }
        //Create table
        static void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand sqliteCommand;
            string createSQL = "CREATE TABLE Members(Name VARCHAR(100), Channel VARCHAR(100), Description VARCHAR(100))";
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = createSQL;
            sqliteCommand.ExecuteNonQuery();
        }
        //Insert Values
        static void InsertData(SQLiteConnection conn)
        {
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = "INSERT INTO Members(Name, Channel, Description) VALUES ('Mori Calliope', 'https://www.youtube.com/@MoriCalliope', 'Grim Reaper Idol of HoloEN! Love making music!!');";
            sqliteCommand.ExecuteNonQuery();
        }

        //Read data
        static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqliteReader;
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = "SELECT * FROM Members";
            sqliteReader = sqliteCommand.ExecuteReader();
            while (sqliteReader.Read())
            {
                string readerString = sqliteReader.GetString(0);
                Console.WriteLine(readerString);
            }
            conn.Close();
        }
    }
}