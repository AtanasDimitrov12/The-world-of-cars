﻿using System;
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

        public string RemoveCar(int CarId)
        {
            int rows = -1;
            try
            {
                RemoveCarDescription(CarId);
                RemoveCarExtras(CarId);
                RemoveCarPictures(CarId);
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[Cars] WHERE [CarId] = @CarId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@CarId", CarId);
                rows = cmd.ExecuteNonQuery();
                
                return "done";
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }

        public string RemoveCarDescription(int CarId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[CarDescription] WHERE [CarId] = @CarId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@CarId", CarId);
                rows = cmd.ExecuteNonQuery();

                return "done";
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }

        public string RemoveCarExtras(int CarId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[CarExtras] WHERE [CarId] = @CarId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@CarId", CarId);
                rows = cmd.ExecuteNonQuery();

                return "done";
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";     }
            finally { connectionString.Close(); }
        }

        public string RemoveCarPictures(int CarId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[CarPictures] WHERE [CarId] = @CarId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@CarId", CarId);
                rows = cmd.ExecuteNonQuery();

                return "done";
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }

        public string RemoveNews(int NewsId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[News] WHERE [NewsId] = @NewsId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@NewsId", NewsId);
                rows = cmd.ExecuteNonQuery();

                return "done";
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }

        public string RemoveComment(int CommentId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[Comments] WHERE [CommentId] = @CommentId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@CommentId", CommentId);
                rows = cmd.ExecuteNonQuery();

                return "done";
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }

        public string RemoveExtra(int ExtraId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbi530410_carapp].[dbo].[Extras] WHERE [ExtraId] = @ExtraId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@ExtraId", ExtraId);
                rows = cmd.ExecuteNonQuery();

                return "done";
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }

        public string RemovePicture(int PicId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbi530410_carapp].[dbo].[Pictures] WHERE [PictureId] = @PicId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@PicId", PicId);
                rows = cmd.ExecuteNonQuery();

                return "done";
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }

        public string RemoveRental(int RentalId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[Rentals] WHERE [RentalId] = @RentalId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@RentalId", RentalId);
                rows = cmd.ExecuteNonQuery();

                return "done";
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }

        public string RemoveUser(int UserId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[Users] WHERE [UserId] = @UserId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                rows = cmd.ExecuteNonQuery();

                return "done";
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }

        public string RemoveAdmin(int AdminId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[Administration] WHERE [AdminId] = @AdminId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@AdminId", AdminId);
                rows = cmd.ExecuteNonQuery();

                return "done";
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }
    }
}
