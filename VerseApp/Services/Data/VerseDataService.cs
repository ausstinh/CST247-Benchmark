using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VerseApp.Models;
using VerseApp.Services.Utility;

namespace VerseApp.Services.Data
{
    public class VerseDataService
    {
        private static MyLogger logger = MyLogger.GetInstance();

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Verse;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool Create(VerseModel verse)
        {
            logger.Info("Entering VerseDataService.Create() with " + verse);

            bool success = false;

            string queryString = "INSERT INTO dbo.verses (TESTAMENT, BOOK, CHAPTER, VERSE, TEXT) VALUES (@TESTAMENT, @BOOK, @CHAPTER, @VERSE, @TEXT)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@TESTAMENT", System.Data.SqlDbType.VarChar, 40).Value = verse.Testament;
                command.Parameters.Add("@BOOK", System.Data.SqlDbType.VarChar, 40).Value = verse.Book;
                command.Parameters.Add("@CHAPTER", System.Data.SqlDbType.VarChar, 40).Value = verse.Chapter;
                command.Parameters.Add("@VERSE", System.Data.SqlDbType.VarChar, 40).Value = verse.Verse;
                command.Parameters.Add("@TEXT", System.Data.SqlDbType.VarChar, 1000).Value = verse.Text;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.RecordsAffected > 0)
                    {
                        success = true;
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            logger.Info("Exiting VerseDataService.Create() with " + success);
            return success;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public VerseModel Read(VerseModel verse)
        {
            logger.Info("Entering VerseDataService.Read() with " + verse);

            VerseModel result = new VerseModel();

            string queryString = "SELECT * FROM dbo.verses WHERE (TESTAMENT LIKE @TESTAMENT) AND (BOOK LIKE @BOOK) AND (CHAPTER LIKE @CHAPTER) AND (VERSE LIKE @VERSE)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@TESTAMENT", System.Data.SqlDbType.VarChar, 40).Value = "%" + verse.Testament + "%";
                command.Parameters.Add("@BOOK", System.Data.SqlDbType.VarChar, 40).Value = "%" + verse.Book + "%";
                command.Parameters.Add("@CHAPTER", System.Data.SqlDbType.VarChar, 40).Value = "%" + verse.Chapter + "%";
                command.Parameters.Add("@VERSE", System.Data.SqlDbType.VarChar, 40).Value = "%" + verse.Verse + "%";

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        result = new VerseModel(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            logger.Info("Exiting VerseDataService.Read() with " + result);
            return result;
        }

        public List<VerseModel> ReadAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(VerseModel verse)
        {
            throw new NotImplementedException();
        }

    }
}
