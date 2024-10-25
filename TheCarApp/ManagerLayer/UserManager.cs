using AutoMapper;
using InterfaceLayer;
using Data.Models;
using DTO;

namespace ManagerLayer
{
    public class UserManager : IUserManager
    {
        private readonly IPeopleDataWriter _writer;
        private readonly IPeopleDataRemover _remover;
        private readonly IDataAccess _access;
        private readonly IMapper _mapper;
        private readonly List<UserDTO> _users;

        public UserManager(IDataAccess dataAccess, IPeopleDataWriter dataWriter, IPeopleDataRemover dataRemover, IMapper mapper)
        {
            _writer = dataWriter;
            _remover = dataRemover;
            _access = dataAccess;
            _mapper = mapper;
            _users = new List<UserDTO>();
        }

        public async Task<(bool Success, string ErrorMessage)> AddUserAsync(UserDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO);
                await _writer.AddUserAsync(user);

                user.UserId = await _writer.GetUserIdAsync(user.Email);
                _users.Add(userDTO);

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool Success, string ErrorMessage)> UploadProfilePictureAsync(UserDTO userDTO, string relativeFilePath)
        {
            try
            {
                await _remover.RemoveProfilePictureAsync(userDTO.Id);
                await _writer.UploadProfilePictureAsync(userDTO.Id, relativeFilePath);
                userDTO.ProfilePictureFilePath = relativeFilePath;

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public string GetProfilePicPathById(int userId)
        {
            var user = _users.FirstOrDefault(u => u.Id == userId);
            return user?.ProfilePictureFilePath ?? string.Empty;
        }

        public async Task<(bool Success, string ErrorMessage)> RemoveUserAsync(UserDTO userDTO)
        {
            try
            {
                await _remover.RemoveUserAsync(userDTO.Id);
                _users.Remove(userDTO);
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool Success, string ErrorMessage)> UpdateUserAsync(UserDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO);
                await _writer.UpdateUserAsync(user);

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public string GetUserNameById(int userId)
        {
            var user = _users.FirstOrDefault(u => u.Id == userId);
            return user?.Username ?? string.Empty;
        }

        public List<UserDTO> GetAllUsers()
        {
            return _users;
        }

        public UserDTO FindUserById(int userId)
        {
            var user = _users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                return user;
            }

            // If user is not in memory (_users list), retrieve it from the database
            var userFromDb = _access.GetUsersAsync().Result.FirstOrDefault(u => u.UserId == userId);

            if (userFromDb != null)
            {
                // Map the entity to UserDTO and add it to the in-memory list
                UserDTO userDTO = _mapper.Map<UserDTO>(userFromDb);
                _users.Add(userDTO);
                return userDTO;
            }

            // Return null if the user is not found
            return null;
        }

        public UserDTO FindUserByEmail(string Email)
        {
            var user = _users.FirstOrDefault(u => u.Email == Email);

            if (user != null)
            {
                return user;
            }

            // If user is not in memory (_users list), retrieve it from the database
            var userFromDb = _access.GetUsersAsync().Result.FirstOrDefault(u => u.Email == Email);

            if (userFromDb != null)
            {
                // Map the entity to UserDTO and add it to the in-memory list
                UserDTO userDTO = _mapper.Map<UserDTO>(userFromDb);
                _users.Add(userDTO);
                return userDTO;
            }

            // Return null if the user is not found
            return null;
        }


        public async Task<(bool Success, string ErrorMessage)> LoadUsersAsync()
        {
            try
            {
                var loadUsers = await _access.GetUsersAsync();
                if (loadUsers != null)
                {
                    _users.Clear();
                    foreach (var user in loadUsers)
                    {
                        UserDTO usr = _mapper.Map<UserDTO>(user);
                        _users.Add(usr);
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
