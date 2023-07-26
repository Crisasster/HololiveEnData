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
        class Members
        {
            public class Council
            {
                public int id;
                public string Name;
                public string Channel;
                public string Description;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello. Virtual Youtubers are streamers who use virtual avatars.");
            Console.WriteLine("You may have heard of Kizuna Ai, she is known to be the first vtuber.");
            Console.WriteLine("Hololive is currently the power house of vtubers.");
            Console.WriteLine("Besides their Japanese branch, they also have English and Indonesian Branches");

            //create connection
            SQLiteConnection sqliteConnection;
            sqliteConnection = CreateConnection();
            CreateTable(sqliteConnection);
            InsertData(sqliteConnection);
            ReadData(sqliteConnection);
        }

        //set up connection to database
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
            sqliteCommand.CommandText = "INSERT INTO Members(Name, Channel, Description) VALUES ('Takanashi Kiara', 'https://www.youtube.com/@TakanashiKiara', 'An idol whose dream is to become a fast food shop owner. She is a phoenix NOT a chicken or turkey. Very important');";
            sqliteCommand.ExecuteNonQuery();
            sqliteCommand.CommandText = "INSERT INTO Members(Name, Channel, Description) VALUES ('Ninomae Inanis', 'https://www.youtube.com/@NinomaeInanis', 'She began her VTuber activities to deliver random sanity checks on humanity as an ordinary girl.');";
            sqliteCommand.ExecuteNonQuery();
            sqliteCommand.CommandText = "INSERT INTO Members(Name, Channel, Description) VALUES ('Watson Amelia', 'https://www.youtube.com/@WatsonAmelia', 'Weekend Streams ~ Detective. Gamer. Idol? Ame!');";
            sqliteCommand.ExecuteNonQuery();
            sqliteCommand.CommandText = "INSERT INTO Members(Name, Channel, Description) VALUES ('Gawr Gura', 'https://www.youtube.com/@GawrGura', 'Shark-girl Idol of Hololive EN!');";
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