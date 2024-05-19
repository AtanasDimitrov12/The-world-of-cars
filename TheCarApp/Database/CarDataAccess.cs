using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class CarDataAccess
    {
        private readonly string ConnectionString;

        public CarDataAccess()
        {
            ConnectionString = "Server=mssqlstud.fhict.local;Database=dbi530410_carapp;User Id=dbi530410_carapp;Password=Fontyspass;TrustServerCertificate=True;";
        }

        public List<CarDTO> GetCars()
        {
            List<CarDTO> carsDTO = new List<CarDTO>();
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var sql = @"SELECT Cars.CarId, Cars.Brand, Cars.Model, Cars.FirstRegistration, Cars.Mileage, 
                        Cars.Fuel, Cars.EngineSize, Cars.[Power], Cars.Gearbox, Cars.NumberOfSeats, 
                        Cars.NumberOfDoors, Cars.Color, Cars.VIN, Cars.[Status], 
                        CarDescription.[CarDescription], CarDescription.PricePerDay,
                        ISNULL(CarViews.ViewCount, 0) AS ViewCount
                        FROM Cars 
                        INNER JOIN CarDescription ON Cars.CarId = CarDescription.CarId
                        LEFT JOIN CarViews ON Cars.CarId = CarViews.CarId;";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var carDTO = new CarDTO
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("CarId")),
                                    Brand = reader.GetString(reader.GetOrdinal("Brand")),
                                    Model = reader.GetString(reader.GetOrdinal("Model")),
                                    FirstRegistration = reader.GetDateTime(reader.GetOrdinal("FirstRegistration")),
                                    Mileage = reader.GetInt32(reader.GetOrdinal("Mileage")),
                                    Fuel = reader.GetString(reader.GetOrdinal("Fuel")),
                                    EngineSize = reader.GetInt32(reader.GetOrdinal("EngineSize")),
                                    HorsePower = reader.GetInt32(reader.GetOrdinal("Power")),
                                    Gearbox = reader.GetString(reader.GetOrdinal("Gearbox")),
                                    NumberOfSeats = reader.GetInt32(reader.GetOrdinal("NumberOfSeats")),
                                    NumberOfDoors = reader.GetString(reader.GetOrdinal("NumberOfDoors")),
                                    Color = reader.GetString(reader.GetOrdinal("Color")),
                                    VIN = reader.GetString(reader.GetOrdinal("VIN")),
                                    Description = reader.GetString(reader.GetOrdinal("CarDescription")),
                                    PricePerDay = Convert.ToDecimal(reader.GetDouble(reader.GetOrdinal("PricePerDay"))),
                                    CarStatus = reader.GetString(reader.GetOrdinal("Status")),
                                    Views = reader.GetInt32(reader.GetOrdinal("ViewCount"))
                                };
                                carsDTO.Add(carDTO);
                            }
                        }
                    }
                    foreach (var car in carsDTO)
                    {
                        car.CarExtras = GetCarExtras(car.Id, connection);
                        car.Pictures = GetCarPictures(car.Id, connection);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException($"Database error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred: {ex.Message}", ex);
            }
            return carsDTO;
        }




        private List<ExtraDTO> GetCarExtras(int carId, SqlConnection connection)
        {
            var extras = new List<ExtraDTO>();
            var sql = @"SELECT Extras.ExtraId, Extras.ExtraName FROM CarExtras 
                    INNER JOIN Extras ON CarExtras.ExtraId = Extras.ExtraId 
                    WHERE CarExtras.CarId = @CarId";

            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@CarId", carId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        extras.Add(new ExtraDTO
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("ExtraId")),
                            extraName = reader.GetString(reader.GetOrdinal("ExtraName"))
                        });
                    }
                }
            }
            return extras;
        }

        public List<ExtraDTO> GetAllExtras()
        {
            var extras = new List<ExtraDTO>();
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var sql = @"SELECT [ExtraId], [ExtraName] FROM [dbi530410_carapp].[dbo].[Extras];";
                    connection.Open();

                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var extra = new ExtraDTO
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("ExtraId")),
                                    extraName = reader.GetString(reader.GetOrdinal("ExtraName"))
                                };
                                extras.Add(extra);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException($"Database error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred: {ex.Message}", ex);
            }

            return extras;
        }


        private List<PictureDTO> GetCarPictures(int carId, SqlConnection connection)
        {
            var pictures = new List<PictureDTO>();
            var sql = @"SELECT Pictures.[PictureId], Pictures.[PictureURL] FROM CarPictures 
                    INNER JOIN Pictures ON CarPictures.PictureId = Pictures.PictureId 
                    WHERE CarPictures.CarId = @CarId";

            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@CarId", carId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pictures.Add(new PictureDTO
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("PictureId")),
                            PictureURL = reader.GetString(reader.GetOrdinal("PictureURL"))
                        });
                    }
                }
            }
            return pictures;
        }

        public List<PictureDTO> GetAllPictures()
        {
            var pictures = new List<PictureDTO>();
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var sql = @"SELECT [PictureId], [PictureURL] FROM [dbi530410_carapp].[dbo].[Pictures];";
                    connection.Open();

                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var picture = new PictureDTO
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("PictureId")),
                                    PictureURL = reader.GetString(reader.GetOrdinal("PictureURL"))
                                };
                                pictures.Add(picture);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException($"Database error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred: {ex.Message}", ex);
            }

            return pictures;
        }

        public CarDTO GetCarById(int carId)
        {
            CarDTO car = null;
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var sql = @"SELECT Cars.Id, Cars.Brand, Cars.Model, Cars.FirstRegistration, Cars.Mileage, 
                            Cars.Fuel, Cars.EngineSize, Cars.HorsePower, Cars.Gearbox, Cars.NumberOfSeats, 
                            Cars.NumberOfDoors, Cars.Color, Cars.VIN, CarDescription.Description, 
                            CarDescription.PricePerDay, Cars.CarStatus
                            FROM Cars
                            INNER JOIN CarDescription ON Cars.Id = CarDescription.CarId
                            WHERE Cars.Id = @CarId";
                    connection.Open();

                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@CarId", carId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                car = new CarDTO
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Brand = reader.GetString(reader.GetOrdinal("Brand")),
                                    Model = reader.GetString(reader.GetOrdinal("Model")),
                                    FirstRegistration = reader.GetDateTime(reader.GetOrdinal("FirstRegistration")),
                                    Mileage = reader.GetInt32(reader.GetOrdinal("Mileage")),
                                    Fuel = reader.GetString(reader.GetOrdinal("Fuel")),
                                    EngineSize = reader.GetInt32(reader.GetOrdinal("EngineSize")),
                                    HorsePower = reader.GetInt32(reader.GetOrdinal("HorsePower")),
                                    Gearbox = reader.GetString(reader.GetOrdinal("Gearbox")),
                                    NumberOfSeats = reader.GetInt32(reader.GetOrdinal("NumberOfSeats")),
                                    NumberOfDoors = reader.GetString(reader.GetOrdinal("NumberOfDoors")),
                                    Color = reader.GetString(reader.GetOrdinal("Color")),
                                    VIN = reader.GetString(reader.GetOrdinal("VIN")),
                                    Description = reader.GetString(reader.GetOrdinal("Description")),
                                    PricePerDay = reader.GetDecimal(reader.GetOrdinal("PricePerDay")),
                                    CarStatus = reader.GetString(reader.GetOrdinal("CarStatus")),
                                    Pictures = new List<PictureDTO>(),
                                    CarExtras = new List<ExtraDTO>()
                                };


                            }
                        }
                    }

                    if (car != null)
                    {
                        car.Pictures = GetCarPictures(carId, connection);
                        car.CarExtras = GetCarExtras(carId, connection);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException($"Database error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred: {ex.Message}", ex);
            }

            return car;
        }

    }
}
