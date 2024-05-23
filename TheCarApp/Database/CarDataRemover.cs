using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class CarDataRemover : ICarDataRemover
    {
        private SqlConnection connectionString;

        public CarDataRemover()
        {
            connectionString = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi530410_carapp;User Id=dbi530410_carapp;Password=Fontyspass;TrustServerCertificate=True;");
        }

        public void RemoveCar(int CarId)
        {
            int rows = -1;
            try
            {
                RemoveCarDescription(CarId);
                RemoveCarExtras(CarId);
                RemoveCarPictures(CarId);
                RemoveCarViewsHistory(CarId);
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[Cars] WHERE [CarId] = @CarId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@CarId", CarId);
                rows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally { connectionString.Close(); }
        }

        public void RemoveCarDescription(int CarId)
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
        }

        public void RemoveCarExtras(int CarId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[CarExtras] WHERE [CarId] = @CarId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@CarId", CarId);
                rows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally { connectionString.Close(); }
        }

        public void RemoveCarPictures(int CarId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[CarPictures] WHERE [CarId] = @CarId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@CarId", CarId);
                rows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally { connectionString.Close(); }
        }

        public void RemoveCarViewsHistory(int CarId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[CarViews] WHERE [CarID] = @CarId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@CarId", CarId);
                rows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally { connectionString.Close(); }
        }

        public void RemoveExtra(int ExtraId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbi530410_carapp].[dbo].[Extras] WHERE [ExtraId] = @ExtraId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@ExtraId", ExtraId);
                rows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally { connectionString.Close(); }
        }

        public void RemovePicture(int PicId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbi530410_carapp].[dbo].[Pictures] WHERE [PictureId] = @PicId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@PicId", PicId);
                rows = cmd.ExecuteNonQuery();

                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally { connectionString.Close(); }
        }
    }
}
