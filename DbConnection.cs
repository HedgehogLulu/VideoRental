using System;
using System.Data.SQLite;

namespace CourseWork
{
    internal class DbConnection
    {
        private static string connectionString = "Data Source=VideoLibrary.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {

            var connection = new SQLiteConnection(connectionString);
            connection.Open(); // Автоматическое открытие соединения
            return connection;
        }
       
    }
}
