﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer;
using EntityLayout;

namespace Database
{
    public class DataAccess : IDataAccess
    {
        private string connectionString;

        public DataAccess()
        {
            connectionString = "Server=mssqlstud.fhict.local;Database=dbi530410_carapp;User Id=dbi530410_carapp;Password=Fontyspass;TrustServerCertificate=True;";
        }


        public List<CarDTO> GetCars()
        {
            List<CarDTO> carsDTO = new List<CarDTO>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
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
                Console.WriteLine($"Database error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}", ex);
            }
            return carsDTO;
        }




        private List<ExtraDTO> GetCarExtras(int carId, SqlConnection connection)
        {
            var extras = new List<ExtraDTO>();
            try
            {
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
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}", ex);
            }
            return extras;
        }

        public List<ExtraDTO> GetAllExtras()
        {
            var extras = new List<ExtraDTO>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
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
                Console.WriteLine($"Database error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}", ex);
            }

            return extras;
        }


        private List<PictureDTO> GetCarPictures(int carId, SqlConnection connection)
        {
            var pictures = new List<PictureDTO>();
            try
            {
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
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}", ex);
            }
            return pictures;
        }

        public List<PictureDTO> GetAllPictures()
        {
            var pictures = new List<PictureDTO>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
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
                Console.WriteLine($"Database error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}", ex);
            }

            return pictures;
        }



        public List<CarNewsDTO> GetCarNews()
        {
            List<CarNewsDTO> newsDTOList = new List<CarNewsDTO>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = @"SELECT [NewsId], [Author], [Title], [DatePosted], [NewsDescription], [ImageURL], [ShortIntro] FROM [dbi530410_carapp].[dbo].[News];
";
                    connection.Open();

                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var newsDTO = new CarNewsDTO
                                {
                                    // Initialize your CarNewsDTO properties here
                                    Id = reader.GetInt32(reader.GetOrdinal("NewsId")),
                                    NewsDescription = reader.GetString(reader.GetOrdinal("NewsDescription")),
                                    ReleaseDate = reader.GetDateTime(reader.GetOrdinal("DatePosted")),
                                    ImageURL = reader.GetString(reader.GetOrdinal("ImageURL")),
                                    Title = reader.GetString(reader.GetOrdinal("Title")),
                                    Author = reader.GetString(reader.GetOrdinal("Author")),
                                    ShortIntro = reader.GetString(reader.GetOrdinal("ShortIntro")),
                                    comments = new List<CommentDTO>() // Initialize comments
                                };
                                newsDTOList.Add(newsDTO);
                            }
                        }
                    }

                    foreach (var news in newsDTOList)
                    {
                        news.comments = GetCommentsForNews(news.Id);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}", ex);
            }
            return newsDTOList;
        }

        public List<CommentDTO> GetCommentsForNews(int newsId)
        {
            List<CommentDTO> comments = new List<CommentDTO>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = @"SELECT CommentId, UserID, CommentDate, Content FROM [dbi530410_carapp].[dbo].[Comments] WHERE NewsId = @NewsId";
                    connection.Open();

                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@NewsId", newsId);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comments.Add(new CommentDTO
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("CommentId")),
                                    Content = reader.GetString(reader.GetOrdinal("Content")),
                                    Date = reader.GetDateTime(reader.GetOrdinal("CommentDate")),
                                    UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}", ex);
            }
            return comments;
        }

        public List<RentACarDTO> GetRentals()
        {
            List<RentACarDTO> rentals = new List<RentACarDTO>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = @"SELECT RentalId, UserId, CarId, StartDate, EndDate, Status FROM [dbi530410_carapp].[dbo].[Rentals]";
                    connection.Open();

                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var rental = new RentACarDTO
                                {
                                    UserID = reader.GetInt32(reader.GetOrdinal("UserId")),
                                    CarId = reader.GetInt32(reader.GetOrdinal("CarId")),
                                    StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                    ReturnDate = reader.GetDateTime(reader.GetOrdinal("EndDate")),
                                    Status = reader.GetString(reader.GetOrdinal("Status"))
                                };
                                rentals.Add(rental);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}", ex);
            }
            return rentals;
        }


        public UserDTO GetUserById(int userId)
        {
            UserDTO user = null;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = @"SELECT UserId, Username, Email, PasswordHash, LicenseNumber, CreatedOn, Salt FROM [dbi530410_carapp].[dbo].[Users] WHERE UserId = @UserId";
                    connection.Open();

                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        using (var reader = command.ExecuteReader())
                        {

                            user = new UserDTO
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("UserId")),
                                email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                password = reader.IsDBNull(reader.GetOrdinal("PasswordHash")) ? null : reader.GetString(reader.GetOrdinal("PasswordHash")),
                                passSalt = reader.IsDBNull(reader.GetOrdinal("Salt")) ? null : reader.GetString(reader.GetOrdinal("Salt")),
                                Username = reader.IsDBNull(reader.GetOrdinal("Username")) ? null : reader.GetString(reader.GetOrdinal("Username")),
                                CreatedOn = reader.GetDateTime(reader.GetOrdinal("CreatedOn")),
                                _licenseNumber = reader.GetInt32(reader.GetOrdinal("LicenseNumber"))
                            };

                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}", ex);
            }

            return user;
        }

        public CarDTO GetCarById(int carId)
        {
            CarDTO car = null;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = @"SELECT Cars.CarId, Cars.Brand, Cars.Model, Cars.FirstRegistration, Cars.Mileage, 
                        Cars.Fuel, Cars.EngineSize, Cars.[Power], Cars.Gearbox, Cars.NumberOfSeats, 
                        Cars.NumberOfDoors, Cars.Color, Cars.VIN, Cars.[Status], 
                        CarDescription.[CarDescription], CarDescription.PricePerDay,
                        ISNULL(CarViews.ViewCount, 0) AS ViewCount
                        FROM Cars 
                        INNER JOIN CarDescription ON Cars.CarId = CarDescription.CarId
                        LEFT JOIN CarViews ON Cars.CarId = CarViews.CarId
                        WHERE Cars.Id = @CarId;";
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
                Console.WriteLine($"Database error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}", ex);
            }

            return car;
        }

        public List<UserDTO> GetUsers()
        {
            List<UserDTO> users = new List<UserDTO>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = @"SELECT u.UserId, u.Username, u.Email, u.PasswordHash, u.LicenseNumber, u.CreatedOn, u.Salt, upp.FilePath 
                              FROM [dbi530410_carapp].[dbo].[Users] u
                              INNER JOIN [dbi530410_carapp].[dbo].[UserProfilePictures] upp
                              ON u.UserId = upp.UserId";

                    connection.Open();

                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var user = new UserDTO
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("UserId")),
                                    email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                    password = reader.IsDBNull(reader.GetOrdinal("PasswordHash")) ? null : reader.GetString(reader.GetOrdinal("PasswordHash")),
                                    passSalt = reader.IsDBNull(reader.GetOrdinal("Salt")) ? null : reader.GetString(reader.GetOrdinal("Salt")),
                                    Username = reader.IsDBNull(reader.GetOrdinal("Username")) ? null : reader.GetString(reader.GetOrdinal("Username")),
                                    CreatedOn = reader.GetDateTime(reader.GetOrdinal("CreatedOn")),
                                    _licenseNumber = reader.GetInt32(reader.GetOrdinal("LicenseNumber")),
                                    ProfilePicturePath = reader.GetString(reader.GetOrdinal("FilePath"))
                                };
                                users.Add(user);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}", ex);
            }

            return users;
        }



        public List<AdministratorDTO> GetAdministrators()
        {
            List<AdministratorDTO> administrators = new List<AdministratorDTO>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = @"SELECT AdminId, Username, Email, PasswordHash, PhoneNumber, CreatedOn, PassSalt FROM [dbi530410_carapp].[dbo].[Admininstration]";
                    connection.Open();

                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var administrator = new AdministratorDTO
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("AdminId")),
                                    email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                    password = reader.IsDBNull(reader.GetOrdinal("PasswordHash")) ? null : reader.GetString(reader.GetOrdinal("PasswordHash")),
                                    Username = reader.IsDBNull(reader.GetOrdinal("Username")) ? null : reader.GetString(reader.GetOrdinal("Username")),
                                    CreatedOn = reader.GetDateTime(reader.GetOrdinal("CreatedOn")),
                                    _phoneNumber = reader.IsDBNull(reader.GetOrdinal("PhoneNumber")) ? null : reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                    passSalt = reader.IsDBNull(reader.GetOrdinal("PassSalt")) ? null : reader.GetString(reader.GetOrdinal("PassSalt"))

                                };
                                administrators.Add(administrator);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}", ex);
            }

            return administrators;
        }
    }
}