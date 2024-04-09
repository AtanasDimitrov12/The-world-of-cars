using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace Database
{
    public class DataWriter
    {
        private SqlConnection connectionString;

        public DataWriter()
        { 
            connectionString = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi530410_carapp;User Id=dbi530410_carapp;Password=Fontyspass;TrustServerCertificate=True;"); 
        }

        public int AddCar(string Brand, string Model, DateTime FirstRegistration, int Mileage, string Fuel, int EngineSize, int HP, string Gearbox, int NumOfSeats, string NumOfDoors, string color, string VIN, string Status)
        {
            int rows = -1;
            try
            {

                connectionString.Open();
                var sql = "INSERT INTO [dbo].[Cars] ([Brand], [Model], [FirstRegistration], [Mileage], [Fuel], [EngineSize], [Power], [Gearbox], [NumberOfSeats], [NumberOfDoors], [Color], [VIN], [Status]) " +
                    "VALUES (@Brand, @Model, @FirstRegistration, @Mileage, @Fuel, @EngineSize, @HP, @Gearbox, @NumOfSeats, @NumOfDoors, @color, @VIN, @Status)";

                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@Brand", Brand);
                cmd.Parameters.AddWithValue("@Model", Model);
                cmd.Parameters.AddWithValue("@FirstRegistration", FirstRegistration);
                cmd.Parameters.AddWithValue("@Mileage", Mileage);
                cmd.Parameters.AddWithValue("@Fuel", Fuel);
                cmd.Parameters.AddWithValue("@EngineSize", EngineSize);
                cmd.Parameters.AddWithValue("@HP", HP);
                cmd.Parameters.AddWithValue("@Gearbox", Gearbox);
                cmd.Parameters.AddWithValue("@NumOfSeats", NumOfSeats);
                cmd.Parameters.AddWithValue("@NumOfDoors", NumOfDoors);
                cmd.Parameters.AddWithValue("@color", color);
                cmd.Parameters.AddWithValue("@VIN", VIN);
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
            return rows;
        }

        public int AddCarDescription(int CarId, string Description, decimal Price)
        {
            int rows = -1;
            try
            {

                connectionString.Open();
                var sql = "INSERT INTO [dbo].[CarDescription] ([CarId], [CarDescription], [PricePerDay]) " +
                    "VALUES (@CarId, @Description, @PricePerDay);";

                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@CarId", CarId);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@PricePerDay", Price);

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
            return rows;
        }

        public int AddCarExtras(int CarId, int ExtraId)
        {
            int rows = -1;
            try
            {

                connectionString.Open();
                var sql = "INSERT INTO [dbo].[CarExtras] ([CarId], [ExtraId]) " +
                    "VALUES (@CarId, @ExtraId)";

                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@CarId", CarId);
                cmd.Parameters.AddWithValue("@ExtraId", ExtraId);

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
            return rows;
        }

        public int AddCarPictures(int CarId, int PictureId)
        {
            int rows = -1;
            try
            {

                connectionString.Open();
                var sql = "INSERT INTO [dbo].[CarPictures] ([PictureID], [CarID]) " +
                    "VALUES (@PictureId, @CarId)";

                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@CarId", CarId);
                cmd.Parameters.AddWithValue("@PictureId", PictureId);

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
            return rows;
        }

        public int AddCarNews(string Author, string Title, DateTime DatePosted, string NewsDescription, string ImageURL, string Intro)
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
            return rows;
        }

        public int AddComment(int NewsId, int UserId, DateTime CommentDate, string Content)
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
            return rows;
        }

        public int RentACar(int CarsId, int UserId, DateTime StartDate, DateTime EndDate, string Status)
        {
            int rows = -1;
            try
            {

                connectionString.Open();
                var sql = "INSERT INTO [dbo].[Rentals] ([UserId], [CarId], [StartDate], [EndDate], [Status]) " +
                    "VALUES (@UserId, @CarsId, @StartDate, @EndDate, @Status)";

                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@CarsId,", CarsId);
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
            return rows;
        }

        public int AddUser(string Username, string email, string password, int LicenseNumber, DateTime CreatedOn)
        {
            int rows = -1;
            try
            {

                connectionString.Open();
                var sql = "INSERT INTO [dbo].[Users] ([Username], [Email], [PasswordHash], [LicenseNumber], [CreatedOn])" +
                    "VALUES (@UserName, @Email, @Password, @LicenseNumber, @CreatedOn)";


                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@UserName", Username);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@LicenseNumber", LicenseNumber);
                cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);

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
            return rows;
        }

        public int AddAdmin(string Username, string email, string password, string PhoneNumber, DateTime CreatedOn)
        {
            int rows = -1;
            try
            {

                connectionString.Open();
                var sql = "INSERT INTO [dbo].[Administration] ([Username], [Email], [PasswordHash], [PhoneNumber], [CreatedOn])" +
                    "VALUES (@UserName, @Email, @Password, @PhoneNumber, @CreatedOn)";


                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@UserName", Username);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);

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
            return rows;
        }

        public int AddExtra(string ExtraName)
        {
            int rows = -1;
            try
            {

                connectionString.Open();
                var sql = "INSERT INTO [dbo].[Extras] ([ExtraName])" +
                    "VALUES (@ExtraName)";


                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@ExtraName", ExtraName);

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
            return rows;
        }

        public int AddPicture(string PictureURL)
        {
            int rows = -1;
            try
            {

                connectionString.Open();
                var sql = "INSERT INTO [dbo].[Pictures] ([PictureURL])" +
                    "VALUES (@PictureURL)";


                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@PictureURL", PictureURL);

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
            return rows;
        }

        public int UpdateAdministration(int adminId, string username, string email, string passwordHash, string phoneNumber, DateTime createdOn)
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
                          "[CreatedOn] = @CreatedOn " +
                          "WHERE [AdminId] = @AdminId";

                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@CreatedOn", createdOn);
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
            return rowsAffected;
        }

    }
}
