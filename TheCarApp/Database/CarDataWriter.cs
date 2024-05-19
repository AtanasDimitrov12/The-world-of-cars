using EntityLayout;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class CarDataWriter : ICarDataWriter
    {
        private SqlConnection connectionString;

        public CarDataWriter()
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
                return $"An error occurred in this action: {ex.Message}";
            }
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
                return $"An error occurred in this action: {ex.Message}";
            }
            finally { connectionString.Close(); }
        }

        public string RecordCarView(int CarId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                // SQL query to increment the view count for a given car ID
                var sql = "UPDATE [dbo].[CarViews] SET ViewCount = ViewCount + 1 WHERE CarId = @CarId;";

                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@CarId", CarId);

                rows = cmd.ExecuteNonQuery();
                // If no rows were updated, it means the CarId was not found, so we insert it
                if (rows == 0)
                {
                    sql = "INSERT INTO [dbo].[CarViews] (CarId, ViewCount) VALUES (@CarId, 1);";
                    cmd = new SqlCommand(sql, connectionString);
                    cmd.Parameters.AddWithValue("@CarId", CarId);
                    rows = cmd.ExecuteNonQuery();
                }

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
            finally
            {
                connectionString.Close();
            }
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
                cmd.Parameters.AddWithValue("@Brand", car.Brand);
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

        public string ChangeCarStatus(Car car, string Status)
        {
            int rows = -1;
            try
            {

                connectionString.Open();
                var sql = "UPDATE [dbo].[Cars] SET [Status] = @Status " +
                    "WHERE CarId = @CARID;";

                SqlCommand cmd = new SqlCommand(sql, connectionString);

                cmd.Parameters.AddWithValue("@Status", Status);
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
    }
}
