using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloEnglishData
{
    internal class Council
    {
        public class Members
        {
            public int Id;
            public string Name;
            public string Channel;
            public string Description;

        }
        public static void Write(string message)
        {
            Console.WriteLine($"MessageWriter.Write(message: \"{message}\")");

            SQLiteConnection sqliteConnection;
            sqliteConnection = CreateConnection();
            CreateTable(sqliteConnection);
            InsertData(sqliteConnection);
            ReadData(sqliteConnection);
        }

        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqliteConn;
            sqliteConn = new SQLiteConnection("Data Source=C:\\Users\\goper\\source\\repos\\HololiveQuery\\NewFolder1\\Databased\\HololiveQuery.db; Version = 3; New = True; Compress = True;");
            try
            {
                Console.WriteLine("Connect to SQL Server");
                sqliteConn.Open();
            }
            catch
            {

            }
            return sqliteConn;
        }
        static void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand sqliteCommand;
            string createSQL = "CREATE TABLE Council(Name VARCHAR(100), Channel VARCHAR(100), Description VARCHAR(100))";
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = createSQL;
            sqliteCommand.ExecuteNonQuery();
        }
        //Insert Values
        static void InsertData(SQLiteConnection conn)
        {
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = "INSERT INTO Council(Name, Channel, Description) VALUES ('Ceres Fauna, 'https://www.youtube.com/@CeresFauna', 'Gaming idol kirin from hololive English!');";
            sqliteCommand.ExecuteNonQuery();
            sqliteCommand.CommandText = "INSERT INTO Council(Name, Channel, Description) VALUES ('Ouro Kronii', 'https://www.youtube.com/@OuroKronii', 'A member of the Council and the Warden of Time');";
            sqliteCommand.ExecuteNonQuery();
            sqliteCommand.CommandText = "INSERT INTO Council(Name, Channel, Description) VALUES ('Nanashi Mumei', 'https://www.youtube.com/@NanashiMumei', 'Oh hi!');";
            sqliteCommand.ExecuteNonQuery();
            sqliteCommand.CommandText = "INSERT INTO Council(Name, Channel, Description) VALUES ('Hakos Baelz', 'https://www.youtube.com/@HakosBaelz', 'just a lil rat idol who wants to make you smile!');";
            sqliteCommand.ExecuteNonQuery();
            sqliteCommand.CommandText = "INSERT INTO Council(Name, Channel, Description) VALUES ('Tsukumo Sana', 'https://www.youtube.com/@TsukumoSana', 'Former member July 31, 2022 Graduated.');";
            sqliteCommand.ExecuteNonQuery();
            sqliteCommand.CommandText = "INSERT INTO Council(Name, Channel, Description) VALUES ('IRyS', 'https://www.youtube.com/@IRyS', 'HiRyS, it's IRyS! Your seiso nephilim here to fill the world with hopium');";
            sqliteCommand.ExecuteNonQuery();
        }
        //Read data
        static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqliteReader;
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = "SELECT * FROM Council";
            sqliteReader = sqliteCommand.ExecuteReader();
            while (sqliteReader.Read())
            {
                string readerString = sqliteReader.GetString(0);
                Console.WriteLine(readerString);
            }
            conn.Close();
            Console.ReadKey();
        }
    }
}
