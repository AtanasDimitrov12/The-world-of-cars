using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Models;
using DTO;
using InterfaceLayer;

namespace ManagerLayer
{
    public class ExtraManager : IExtraManager
    {
        public List<ExtraDTO> Extras { get; set; }
        private readonly IDataAccess _dataAccess;
        private readonly ICarDataWriter _dataWriter;
        private readonly ICarDataRemover _dataRemover;
        private readonly IMapper _mapper;

        public ExtraManager(IDataAccess dataAccess, ICarDataWriter dataWriter, ICarDataRemover dataRemover, IMapper mapper)
        {
            Extras = new List<ExtraDTO>();
            _dataAccess = dataAccess;
            _dataWriter = dataWriter;
            _dataRemover = dataRemover;
            _mapper = mapper;

            LoadExtraAsync().Wait(); // Initialize extras list asynchronously
        }

        // Adds a new Extra to the system and maps to ExtraDTO
        public async Task<(bool Success, string ErrorMessage)> AddExtraAsync(ExtraDTO extraDTO)
        {
            try
            {
                // Map DTO to entity
                var extra = _mapper.Map<CarExtra>(extraDTO);

                // Add to the database
                await _dataWriter.AddExtra(extra.ExtraName);

                // Map back to DTO and add to the list
                var updatedExtraDTO = _mapper.Map<ExtraDTO>(extra);
                Extras.Add(updatedExtraDTO);

                return (true, null); // Success
            }
            catch (Exception ex)
            {
                return (false, ex.Message); // Return error message on failure
            }
        }

        // Removes an Extra from the system and maps from ExtraDTO
        public async Task<(bool Success, string ErrorMessage)> RemoveExtraAsync(ExtraDTO extraDTO)
        {
            try
            {
                // Map DTO to entity
                var extra = _mapper.Map<CarExtra>(extraDTO);

                // Remove from the database
                await _dataRemover.RemoveExtraAsync(extra.CarExtraId);

                // Remove from the list
                Extras.Remove(extraDTO);

                return (true, null); // Success
            }
            catch (Exception ex)
            {
                return (false, ex.Message); // Return error message on failure
            }
        }

        // Gets the ID of the Extra based on its name
        public async Task<int> GetExtraIdAsync(string extraName)
        {
            return await _dataWriter.GetExtraId(extraName);
        }

        // Loads Extras from the database and maps to ExtraDTO
        public async Task<(bool Success, string ErrorMessage)> LoadExtraAsync()
        {
            try
            {
                var loadedExtras = await _dataAccess.GetAllExtrasAsync();
                if (loadedExtras != null)
                {
                    Extras.Clear();
                    foreach (var extraDTO in loadedExtras)
                    {
                        // Map each ExtraDTO to its entity
                        var extra = _mapper.Map<ExtraDTO>(extraDTO);
                        Extras.Add(extra);
                    }
                }
                return (true, null); // Success
            }
            catch (Exception ex)
            {
                return (false, ex.Message); // Return error message on failure
            }
        }
    }
}
