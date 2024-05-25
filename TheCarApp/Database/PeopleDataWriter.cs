using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class PeopleDataWriter : IPeopleDataWriter
    {
        private SqlConnection connectionString;

        public PeopleDataWriter()
        {
            connectionString = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi530410_carapp;User Id=dbi530410_carapp;Password=Fontyspass;TrustServerCertificate=True;");
        }

        public void AddUser(string Username, string email, string password, int LicenseNumber, DateTime CreatedOn, string Salt)
        {
            int rows = -1;
            try
            {

                connectionString.Open();
                var sql = "INSERT INTO [dbo].[Users] ([Username], [Email], [PasswordHash], [LicenseNumber], [CreatedOn], [Salt])" +
                    "VALUES (@UserName, @Email, @Password, @LicenseNumber, @CreatedOn, @Salt)";


                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@UserName", Username);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@LicenseNumber", LicenseNumber);
                cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
                cmd.Parameters.AddWithValue("@Salt", Salt);

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

        public void AddAdmin(string Username, string email, string password, string PhoneNumber, DateTime CreatedOn, string PassSalt)
        {
            int rows = -1;
            try
            {

                connectionString.Open();
                var sql = "INSERT INTO [dbo].[Admininstration] ([Username], [Email], [PasswordHash], [PhoneNumber], [CreatedOn], [PassSalt])" +
                    "VALUES (@UserName, @Email, @Password, @PhoneNumber, @CreatedOn, @PassSalt)";


                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@UserName", Username);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
                cmd.Parameters.AddWithValue("@PassSalt", PassSalt);

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

        public void UpdateUser(int userId, string Username, string email, string password, int _licenseNumber, DateTime CreatedOn)
        {
            int rowsAffected = -1;
            try
            {
                connectionString.Open();
                var sql = "UPDATE [dbo].[Users] " +
                          "SET [Username] = @Username, " +
                          "[Email] = @Email, " +
                          "[PasswordHash] = @PasswordHash, " +
                          "[LicenseNumber] = @License, " +
                          "[CreatedOn] = @CreatedOn " +
                          "WHERE [UserId] = @UserId";

                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PasswordHash", password);
                cmd.Parameters.AddWithValue("@PhoneNumber", _licenseNumber);
                cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
                cmd.Parameters.AddWithValue("@UserId", userId);

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

        public void UpdateAdministration(int adminId, string username, string email, string passwordHash, string phoneNumber, DateTime createdOn, string PassSalt)
        {
            int rowsAffected = -1;
            try
            {
                connectionString.Open();
                var sql = "UPDATE [dbo].[Admininstration] " +
                          "SET [Username] = @Username, " +
                          "[Email] = @Email, " +
                          "[PasswordHash] = @PasswordHash, " +
                          "[PhoneNumber] = @PhoneNumber, " +
                          "[CreatedOn] = @CreatedOn, " +
                          "[PassSalt] = @PassSalt " +
                          "WHERE [AdminId] = @AdminId";

                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@CreatedOn", createdOn);
                cmd.Parameters.AddWithValue("@PassSalt", PassSalt);
                cmd.Parameters.AddWithValue("@AdminId", adminId);

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

        public void RentACar(int CarsId, int UserId, DateTime StartDate, DateTime EndDate, string Status)
        {
            int rows = -1;
            try
            {

                connectionString.Open();
                var sql = "INSERT INTO [dbo].[Rentals] ([UserId], [CarId], [StartDate], [EndDate], [Status]) " +
                    "VALUES (@UserId, @CarsId, @StartDate, @EndDate, @Status)";

                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@CarsId", CarsId);
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate);
                cmd.Parameters.AddWithValue("@Status", Status);

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
    }
}
