using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Models;
using DatabaseAccess;
using DTO;
using InterfaceLayer;

namespace Manager_Layer
{
    public class AdministratorManager : IAdministratorManager
    {
        private readonly IPeopleDataWriter _writer;
        private readonly IPeopleDataRemover _remover;
        private readonly IDataAccess _access;
        private readonly IMapper _mapper;
        public List<AdministratorDTO> Admins { get; private set; }

        public AdministratorManager(IDataAccess dataAccess, IPeopleDataWriter dataWriter, IPeopleDataRemover dataRemover, IMapper mapper)
        {
            _writer = dataWriter;
            _access = dataAccess;
            _remover = dataRemover;
            _mapper = mapper;
            Admins = new List<AdministratorDTO>();
        }

        // Adds a new administrator and maps the Administrator to AdministratorDTO
        public async Task<(bool Success, string ErrorMessage)> AddAdminAsync(AdministratorDTO adminDTO)
        {
            try
            {
                var admin = _mapper.Map<Administrator>(adminDTO);

                await _writer.AddAdminAsync(admin);

                Admins.Add(adminDTO);

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        // Removes an administrator and removes it from the DTO list
        public async Task<(bool Success, string ErrorMessage)> RemoveAdminAsync(AdministratorDTO adminDTO)
        {
            try
            {
                await _remover.RemoveAdminAsync(adminDTO.Id);
                Admins.Remove(adminDTO);

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        // Updates an administrator and ensures DTO list consistency
        public async Task<(bool Success, string ErrorMessage)> UpdateAdminAsync(AdministratorDTO adminDTO)
        {
            try
            {
                var admin = _mapper.Map<Administrator>(adminDTO);
                await _writer.UpdateAdminAsync(admin);


                // Find the corresponding admin in the Admins list and update it
                var index = Admins.FindIndex(a => a.Id == admin.Id);
                if (index != -1)
                {
                    Admins[index] = adminDTO;
                }

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        // Gets the list of administrators as DTOs
        public List<AdministratorDTO> GetAllAdministrators()
        {
            return Admins;
        }

        // Loads administrators from the data access layer and maps them to DTOs
        public async Task<(bool Success, string ErrorMessage)> LoadAdminsAsync()
        {
            try
            {
                var loadAdmins = await _access.GetAdministratorsAsync();
                if (loadAdmins != null)
                {
                    // Clear the current list and map all loaded admins to DTOs
                    Admins.Clear();
                    foreach(var admin in loadAdmins)
                    {
                        AdministratorDTO adm= _mapper.Map<AdministratorDTO>(admin);
                        Admins.Add(adm);
                    }
                }
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
