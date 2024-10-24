using AutoMapper;
using Data.Models;
using DTO;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagerLayer
{
    public class PictureManager : IPictureManager
    {
        public List<PictureDTO> Pictures { get; set; }
        private readonly IDataAccess _dataAccess;
        private readonly ICarDataWriter _dataWriter;
        private readonly ICarDataRemover _dataRemover;
        private readonly IMapper _mapper;

        public PictureManager(IDataAccess dataAccess, ICarDataWriter dataWriter, ICarDataRemover dataRemover, IMapper mapper)
        {
            Pictures = new List<PictureDTO>();
            _dataAccess = dataAccess;
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
            _mapper = mapper;

            LoadPicturesAsync().GetAwaiter().GetResult(); // Initialize pictures list
        }

        // Adds a new picture and maps it to DTO
        public async Task<(bool Success, string ErrorMessage)> AddPictureAsync(PictureDTO picDTO)
        {
            try
            {
                // Map DTO to entity
                var picture = _mapper.Map<CarPicture>(picDTO);

                await _dataWriter.AddPicture(picture.PictureURL);

                // Map back to DTO and add to the list
                Pictures.Add(picDTO);

                return (true, null); // Success
            }
            catch (Exception ex)
            {
                return (false, ex.Message); // Return error message on failure
            }
        }

        // Removes a picture
        public async Task<(bool Success, string ErrorMessage)> RemovePictureAsync(PictureDTO picDTO)
        {
            try
            {
                await _dataRemover.RemovePictureAsync(picDTO.Id);
                Pictures.Remove(picDTO);

                return (true, null); // Success
            }
            catch (Exception ex)
            {
                return (false, ex.Message); // Return error message on failure
            }
        }

        // Loads pictures from the database and maps them to DTOs
        public async Task<(bool Success, string ErrorMessage)> LoadPicturesAsync()
        {
            try
            {
                var loadedPics = await _dataAccess.GetAllPicturesAsync();
                if (loadedPics != null)
                {
                    Pictures.Clear();
                    foreach (var pic in loadedPics)
                    {
                        var picDTO = _mapper.Map<PictureDTO>(pic);
                        Pictures.Add(picDTO);
                    }
                }
                return (true, null); // Success
            }
            catch (Exception ex)
            {
                return (false, ex.Message); // Return error message on failure
            }
        }

        // Gets the picture ID from URL
        public async Task<int> GetPicIdAsync(string URL)
        {
            return await _dataWriter.GetPictureId(URL);
        }
    }
}
