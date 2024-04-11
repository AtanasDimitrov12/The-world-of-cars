using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer;

namespace DatabaseAccess
{
    public class DataRemover : IDataRemover
    {
        private SqlConnection connectionString;

        public DataRemover()
        { 
            connectionString = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi530410_carapp;User Id=dbi530410_carapp;Password=Fontyspass;TrustServerCertificate=True;");
        }

        public int RemoveCar(int CarId, int ExtraId, int PictureId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[Cars] WHERE [CarId] = @CarId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@CarId", CarId);
                rows = cmd.ExecuteNonQuery();
                RemoveCarDescription(CarId);
                RemoveCarExtras(CarId, ExtraId);
                RemoveCarPictures(CarId, PictureId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally { connectionString.Close(); }
            return rows;
        }

        public int RemoveCarDescription(int CarId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[CarDescription] WHERE [CarId] = @CarId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@CarId", CarId);
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally { connectionString.Close(); }
            return rows;
        }

        public int RemoveCarExtras(int CarId, int ExtraId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[CarExtras] WHERE [CarId] = @CarId AND [ExtraId] = @ExtraId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@CarId", CarId);
                cmd.Parameters.AddWithValue("@ExtraId", ExtraId);
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally { connectionString.Close(); }
            return rows;
        }

        public int RemoveCarPictures(int CarId, int PictureId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[CarPictures] WHERE [CarId] = @CarId AND [PictureID] = @PictureId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@CarId", CarId);
                cmd.Parameters.AddWithValue("@PictureId", PictureId);
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally { connectionString.Close(); }
            return rows;
        }

        public int RemoveNews(int NewsId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[News] WHERE [NewsId] = @NewsId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@NewsId", NewsId);
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally { connectionString.Close(); }
            return rows;
        }

        public int RemoveComment(int CommentId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[Comments] WHERE [CommentId] = @CommentId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@CommentId", CommentId);
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally { connectionString.Close(); }
            return rows;
        }

        public int RemoveRental(int RentalId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[Rentals] WHERE [RentalId] = @RentalId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@RentalId", RentalId);
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally { connectionString.Close(); }
            return rows;
        }

        public int RemoveUser(int UserId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[Users] WHERE [UserId] = @UserId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally { connectionString.Close(); }
            return rows;
        }

        public int RemoveAdmin(int AdminId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[Administration] WHERE [AdminId] = @AdminId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@AdminId", AdminId);
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally { connectionString.Close(); }
            return rows;
        }
    }
}
