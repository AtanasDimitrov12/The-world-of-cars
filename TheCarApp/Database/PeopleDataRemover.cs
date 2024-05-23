using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class PeopleDataRemover : IPeopleDataRemover
    {
        private SqlConnection connectionString;

        public PeopleDataRemover()
        {
            connectionString = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi530410_carapp;User Id=dbi530410_carapp;Password=Fontyspass;TrustServerCertificate=True;");
        }

        public void RemoveUser(int UserId)
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
        }

        public void RemoveAdmin(int AdminId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbi530410_carapp].[dbo].[Admininstration] WHERE [AdminId] = @AdminId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@AdminId", AdminId);
                rows = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally { connectionString.Close(); }
        }

        public void RemoveRental(int RentalId)
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
        }
    }
}
