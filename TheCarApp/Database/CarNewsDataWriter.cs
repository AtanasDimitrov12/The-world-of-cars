using Entity_Layer;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class CarNewsDataWriter : ICarNewsDataWriter
    {
        private SqlConnection connectionString;

        public CarNewsDataWriter()
        {
            connectionString = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi530410_carapp;User Id=dbi530410_carapp;Password=Fontyspass;TrustServerCertificate=True;");
        }

        public void AddCarNews(string Author, string Title, DateTime DatePosted, string NewsDescription, string ImageURL, string Intro)
        {
            int rows = -1;
            try
            {

                connectionString.Open();
                var sql = "INSERT INTO [dbo].[News] ([Author], [Title], [DatePosted], [NewsDescription], [ImageURL], [ShortIntro]) " +
                    "VALUES (@Author, @Title, @DatePosted, @Description, @ImageURL, @ShortIntro)";


                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@Author", Author);
                cmd.Parameters.AddWithValue("@Title", Title);
                cmd.Parameters.AddWithValue("@DatePosted", DatePosted);
                cmd.Parameters.AddWithValue("@Description", NewsDescription);
                cmd.Parameters.AddWithValue("@ImageURL", ImageURL);
                cmd.Parameters.AddWithValue("@ShortIntro", Intro);

                rows = cmd.ExecuteNonQuery();
                
            }

            catch (SqlException ex)
            {
                Console.WriteLine($"MSSQL error in this action: {ex.Message}");
            }
            catch (Exception ex)
            {   
                Console.WriteLine($"An error occurred in this action: {ex.Message}");
            }
            finally { connectionString.Close(); }
        }

        public void UpdateNews(CarNews news)
        {
            int rowsAffected = -1;
            try
            {
                connectionString.Open();
                var sql = "UPDATE [dbo].[News] SET " +
                          "[Author] = @Author, " +
                          "[Title] = @Title, " +
                          "[DatePosted] = @DatePosted, " +
                          "[NewsDescription] = @NewsDescription, " +
                          "[ImageURL] = @ImageURL, " +
                          "[ShortIntro] = @ShortIntro " +
                          "WHERE NewsId = @NewsId;";

                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@Author", news.Author);
                cmd.Parameters.AddWithValue("@Title", news.Title);
                cmd.Parameters.AddWithValue("@DatePosted", news.ReleaseDate);
                cmd.Parameters.AddWithValue("@NewsDescription", news.NewsDescription);
                cmd.Parameters.AddWithValue("@ImageURL", news.ImageURL);
                cmd.Parameters.AddWithValue("@ShortIntro", news.ShortIntro);
                cmd.Parameters.AddWithValue("@NewsId", news.Id);

                rowsAffected = cmd.ExecuteNonQuery();
                
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Server error in update action: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in the update action: {ex.Message}");
            }
            finally
            {
                connectionString.Close();
            }
        }

        public void AddComment(int NewsId, int UserId, DateTime CommentDate, string Content)
        {
            int rows = -1;
            try
            {

                connectionString.Open();
                var sql = "INSERT INTO [dbo].[Comments] ([NewsId], [UserID], [CommentDate], [Content]) " +
                    "VALUES (@NewsId, @UserId, @CommentDate, @Content)";


                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@NewsId", NewsId);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@CommentDate", CommentDate);
                cmd.Parameters.AddWithValue("@Content", Content);

                rows = cmd.ExecuteNonQuery();
                

            }

            catch (SqlException ex)
            {
                Console.WriteLine($"MSSQL error in this action: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in this action: {ex.Message}");
            }
            finally { connectionString.Close(); }
        }

        public int GetNewsId(string Title)
        {
            int NewsId = -1;
            try
            {
                connectionString.Open();
                var sql = "SELECT [NewsId] FROM [dbi530410_carapp].[dbo].[News] WHERE [Title] = @Title";

                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@Title", Title);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NewsId = (int)reader["NewsId"];
                    }
                }
                
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"MSSQL error in GetNewsId: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in GetNewsId: {ex.Message}");
            }
            finally
            {
                connectionString.Close();
                
            }
            return NewsId;
        }

        public int GetCommentId(DateTime date)
        {
            int CommentId = -1;
            try
            {
                connectionString.Open();
                var sql = "SELECT [CommentId] FROM [dbi530410_carapp].[dbo].[Comments]WHERE [CommentDate] = @Date";

                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@Date", date);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        CommentId = (int)reader["CommentId"];
                    }
                }
                
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"MSSQL error in GetCommentId: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in GetCommentId: {ex.Message}");
            }
            finally
            {
                connectionString.Close();
            }
            return CommentId;
        }
    }
}
