using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using InterfaceLayer;
using EntityLayout;
using Entity_Layer;

namespace Database
{
    public class DataWriter : IDataWriter
    {
        private SqlConnection connectionString;

        public DataWriter()
        { 
            connectionString = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi530410_carapp;User Id=dbi530410_carapp;Password=Fontyspass;TrustServerCertificate=True;"); 
        }

        public string AddCar(string Brand, string Model, DateTime FirstRegistration, int Mileage, string Fuel, int EngineSize, int HP, string Gearbox, int NumOfSeats, string NumOfDoors, string color, string VIN, string Status)
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
                return "done";

            }

            catch (SqlException ex)
            {
                return $"MSSQL error in this action: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in this action: {ex.Message}";
            }
            finally { connectionString.Close(); }
            
        }

        public string AddCarDescription(int CarId, string Description, decimal Price)
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
                return "done";

            }

            catch (SqlException ex)
            {
                return $"MSSQL error in this action: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in this action: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }

        public string AddCarExtras(int CarId, int ExtraId)
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
                return "done";
            }

            catch (SqlException ex)
            {
                return $"MSSQL error in this action: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in this action: {ex.Message}";         }
            finally { connectionString.Close(); }
        }

        public string AddCarPictures(int CarId, int PictureId)
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
                return "done";
            }

            catch (SqlException ex)
            {
                return $"MSSQL error in this action: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in this action: {ex.Message}";  }
            finally { connectionString.Close(); }
        }

        public string UpdateCar(Car car)
        {
            int rows = -1;
            try
            {

                connectionString.Open();
                var sql = "UPDATE [dbo].[Cars] SET [Brand] = @Brand, [Model] = @Model, [FirstRegistration] = @FirstRegistration, [Mileage] = @Mileage, [Fuel] = @Fuel, [EngineSize] = @EngineSize, [Power] = @Power, [Gearbox] = @Gearbox, [NumberOfSeats] = @NumberOfSeats, [NumberOfDoors] = @NumberOfDoors, [Color] = @Color, [VIN] = @VIN, [Status] = @Status " +
                    "WHERE CarId = @CARID;";

                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@Brand", car.brand);
                cmd.Parameters.AddWithValue("@Model", car.Model);
                cmd.Parameters.AddWithValue("@FirstRegistration", car.FirstRegistration);
                cmd.Parameters.AddWithValue("@Mileage", car.Mileage);
                cmd.Parameters.AddWithValue("@Fuel", car.Fuel);
                cmd.Parameters.AddWithValue("@EngineSize", car.EngineSize);
                cmd.Parameters.AddWithValue("@Power", car.HorsePower);
                cmd.Parameters.AddWithValue("@Gearbox", car.Gearbox);
                cmd.Parameters.AddWithValue("@NumberOfSeats", car.NumberOfSeats);
                cmd.Parameters.AddWithValue("@NumberOfDoors", car.NumberOfDoors);
                cmd.Parameters.AddWithValue("@Color", car.Color);
                cmd.Parameters.AddWithValue("@VIN", car.VIN);
                cmd.Parameters.AddWithValue("@Status", car.CarStatus.ToString());
                cmd.Parameters.AddWithValue("@CARID", car.Id);

                rows = cmd.ExecuteNonQuery();
                return "done";
            }

            catch (SqlException ex)
            {
                return $"MSSQL error in this action: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in this action: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }

        public string UpdateCarDescription(Car car)
        {
            int rows = -1;
            try
            {

                connectionString.Open();
                var sql = "UPDATE [dbo].[CarDescription] SET [CarDescription] = @CarDescription, [PricePerDay] = @PricePerDay " +
                    "WHERE CarId = @CARID;";

                SqlCommand cmd = new SqlCommand(sql, connectionString); 

                cmd.Parameters.AddWithValue("@CarDescription", car.Description);
                cmd.Parameters.AddWithValue("@PricePerDay", car.PricePerDay);
                cmd.Parameters.AddWithValue("@CARID", car.Id);

                rows = cmd.ExecuteNonQuery();
                return "done";
            }

            catch (SqlException ex)
            {
                return $"MSSQL error in this action: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in this action: {ex.Message}";
            }
            finally { connectionString.Close(); }
            
        }

        public string RemoveCarExtras(int CarId)
        {
            int rows = -1;
            try
            {

                connectionString.Open();
                var sql = "DELETE FROM [dbo].[CarExtras] WHERE CarId = @carId;";

                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@carId", CarId);

                rows = cmd.ExecuteNonQuery();
                return "done";
            }

            catch (SqlException ex)
            {
                return $"MSSQL error in this action: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in this action: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }

        public string RemoveCarPictures(int CarId)
        {
            int rows = -1;
            try
            {

                connectionString.Open();
                var sql = "DELETE FROM [dbo].[CarPictures] WHERE CarID = @carId;";


                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@carId", CarId);

                rows = cmd.ExecuteNonQuery();
                return "done";
            }

            catch (SqlException ex)
            {
                return $"MSSQL error in this action: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in this action: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }

        public string AddCarNews(string Author, string Title, DateTime DatePosted, string NewsDescription, string ImageURL, string Intro)
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
                return "done";
            }

            catch (SqlException ex)
            {
                return $"MSSQL error in this action: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in this action: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }

        public string UpdateNews(CarNews news)
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
                return "done";
            }
            catch (SqlException ex)
            {
                return $"SQL Server error in update action: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in the update action: {ex.Message}";
            }
            finally
            {
                connectionString.Close();
            }
        }


        public string AddComment(int NewsId, int UserId, DateTime CommentDate, string Content)
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
                return "done";

            }

            catch (SqlException ex)
            {
                return $"MSSQL error in this action: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in this action: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }

        public string RentACar(int CarsId, int UserId, DateTime StartDate, DateTime EndDate, string Status)
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
                return "done";
            }

            catch (SqlException ex)
            {
                return $"MSSQL error in this action: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in this action: {ex.Message}";      
            }
            finally { connectionString.Close(); }
        }

        public string AddUser(string Username, string email, string password, int LicenseNumber, DateTime CreatedOn, string Salt)
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
                return "done";
            }

            catch (SqlException ex)
            {
                return $"MSSQL error in this action: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in this action: {ex.Message}";
            }
            finally { connectionString.Close(); }
            
        }

        public string AddAdmin(string Username, string email, string password, string PhoneNumber, DateTime CreatedOn)
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
                return "done";
            }

            catch (SqlException ex)
            {
                return $"MSSQL error in this action: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in this action: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }

        public string AddExtra(string ExtraName)
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
                return "done";
            }

            catch (SqlException ex)
            {
                return $"MSSQL error in this action: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in this action: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }

        public string AddPicture(string PictureURL)
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
                return "done";
            }

            catch (SqlException ex)
            {
                return $"MSSQL error in this action: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in this action: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }

        public string UpdateUser(int userId, string Username, string email, string password, int _licenseNumber, DateTime CreatedOn)
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
                return "done";
            }
            catch (SqlException ex)
            {
                return $"SQL Server error in update action: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in the update action: {ex.Message}";         }
            finally
            {
                connectionString.Close();
            }
        }

        public string UpdateAdministration(int adminId, string username, string email, string passwordHash, string phoneNumber, DateTime createdOn)
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
                return "done";
            }
            catch (SqlException ex)
            {
                return $"SQL Server error in update action: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in the update action: {ex.Message}";
            }
            finally
            {
                connectionString.Close();
            }
        }

        public string GetCarId(string VIN)
        {
            int carId = -1;
            try
            {
                connectionString.Open();
                var sql = "SELECT [CarId] FROM [dbo].[Cars] WHERE [VIN] = @VIN";

                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@VIN", VIN);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        carId = (int)reader["CarId"];
                    }
                }
                return $"{carId}";
            }
            catch (SqlException ex)
            {
                return $"MSSQL error in GetCarId: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in GetCarId: {ex.Message}";
            }
            finally
            {
                connectionString.Close();
            }
        }

        public string GetExtraId(string ExtraName)
        {
            int ExtraId = -1;
            try
            {
                connectionString.Open();
                var sql = "SELECT [ExtraId] FROM [dbo].[Extras] WHERE [ExtraName] = @ExtraName";

                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@ExtraName", ExtraName);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ExtraId = (int)reader["ExtraId"];
                    }
                }
                return $"{ExtraId}";
            }
            catch (SqlException ex)
            {
                return $"MSSQL error in GetExtraId: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in GetExtraId: {ex.Message}";
            }
            finally
            {
                connectionString.Close();
            }
        }

        public string GetPictureId(string PictureURL)
        {
            int PictureId = -1;
            try
            {
                connectionString.Open();
                var sql = "SELECT [PictureId] FROM [dbo].[Pictures] WHERE [PictureURL] = @PictureURL";

                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@PictureURL", PictureURL);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        PictureId = (int)reader["PictureId"];
                    }
                }
                return $"{PictureId}";
            }
            catch (SqlException ex)
            {
                return $"MSSQL error in GetPictureId: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in GetPictureId: {ex.Message}";
            }
            finally
            {
                connectionString.Close();
            }
        }

        public string GetNewsId(string Title)
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
                return $"{NewsId}";
            }
            catch (SqlException ex)
            {
                return $"MSSQL error in GetNewsId: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in GetNewsId: {ex.Message}";
            }
            finally
            {
                connectionString.Close();
            }
        }

        public string GetCommentId(DateTime date)
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
                return $"{CommentId}";
            }
            catch (SqlException ex)
            {
                return $"MSSQL error in GetCommentId: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"An error occurred in GetCommentId: {ex.Message}";
            }
            finally
            {
                connectionString.Close();
            }
        }

    }
}
